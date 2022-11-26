namespace RemoteLearning.Application.Services;

public class UserService : IUserService
{
    private const int PASSWORD_LENGTH = 12;

    private readonly AppSettings _settings;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;


    public UserService(IUnitOfWork unitOfWork, IEmailService emailService, IMapper mapper, IOptions<AppSettings> settings)
        => (_unitOfWork, _emailService, _mapper, _settings) = (unitOfWork, emailService, mapper, settings.Value);

    public async Task<bool> CreateUsers(IEnumerable<CreateAccountDto> accountDtos)
    {
        foreach(var dto in accountDtos)
        {
            await CreateUser(dto);
        }

        return true;
    }

    private async Task<User> CreateUser(CreateAccountDto accountDto)
    {
        await ValidateAccountData(accountDto);

        var userDetails = _mapper.Map<UserDetails>(accountDto);
        var password = CreatePassword();
        var user = await CreateUser(userDetails, password, accountDto.RoleId);
        await _unitOfWork.Users.Create(user);

        if (await _unitOfWork.SaveChangesAsync() == 0)
        {
            throw new DbUpdateException();
        }
        else
        {
            await _emailService.SendCredentials(user.Username!, password, userDetails.Email);
        }

        return user;
    }

    public async Task<UserDto> Login(LoginDto loginDto)
    {
        var user = await _unitOfWork.Users.GetUserByLogin(loginDto.Username);

        if (user == null)
        {
            throw new InvalidUsernameException("Wprowadzono błędną nazwę użytkownika!");
        }
        else if (string.IsNullOrEmpty(loginDto.Password))
        {
            throw new EnteredNoPasswordException("Wprowadź hasło!");
        }

        using (var hmac = new HMACSHA512(user.PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (!computedHash.ToString()!.Equals(user.PasswordHash.ToString()))
            {
                throw new InvalidPasswordException("Wprowadzono błędne hasło!");
            }

            var token = CreateToken(user);
            var loggedInUser = _mapper.Map<UserDto>(user);
            loggedInUser.Token = CreateToken(user);

            return loggedInUser;
        }
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name!)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_settings.Jwt.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(3),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private async Task<User> CreateUser(UserDetails details, string password, long roleId)
    {
        using (var hmac = new HMACSHA512())
        {
            var user = new User()
            {
                UserDetails = details,
                Username = await CreateUsername(details),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                RoleId = roleId
            };

            return user;
        }
    }

    private async Task<string> CreateUsername(UserDetails details)
    {
        Random rnd = new Random();
        string username = string.Empty;

        username += details.FirstName.Length > 3 ?
            details.FirstName.ToLower().Substring(0, 4) :
            details.FirstName.ToLower();

        username += details.Surname.Length > 3 ?
            details.Surname.ToLower().Substring(0, 4) :
            details.Surname.ToLower();

        username += details.Pesel.ToLower()
            .Substring(0, 2);

        username += rnd.Next(10, 19);

        do
        {
            username += rnd.Next(0, 9);
        } while (await IsUsernameTaken(username));

        return username;
    }

    private string CreatePassword()
    {
        Random rnd = new Random();
        char[] password = new char[PASSWORD_LENGTH];
        HashSet<int> specialCharactersPositions = new HashSet<int>();

        Array.Fill(password, '\0');
        do
        {
            specialCharactersPositions.Add(rnd.Next(0, PASSWORD_LENGTH - 1));
        } while (specialCharactersPositions.Count < 4);

        foreach (var position in specialCharactersPositions)
        {
            password[position] = Convert.ToChar(rnd.Next(33, 47));
        }

        bool isUpperCaseLetter = false;
        for (int i = 0; i < PASSWORD_LENGTH; i++)
        {
            isUpperCaseLetter = rnd.Next(0, 2) % 2 == 0;
            if (password[i] == '\0')
            {
                if (isUpperCaseLetter)
                {
                    password[i] = Convert.ToChar(rnd.Next(65, 90));
                }
                else
                {
                    password[i] = Convert.ToChar(rnd.Next(97, 122));
                }
            }
        }


        return new string(password) ?? "p4$$w0rd";
    }

    private async Task<bool> ValidateAccountData(CreateAccountDto accountDto)
    {
        if (await IsEmailTaken(accountDto.Email))
        {
            throw new EmailTakenException($"Na {accountDto.Email} jest już założone konto w serwisie!");
        }

        if (await IsPeselTaken(accountDto.Pesel))
        {
            throw new PeselTakenException($"PESEL {accountDto.Pesel} widnieje juz w bazie!");
        }
        else if (string.IsNullOrEmpty(accountDto.Pesel))
        {
            throw new EnteredNoPeselException("Wymagane jest podanie numeru pesel!");
        }
        else if(accountDto.Pesel.Length != 11)
        {
            throw new PeselLengthException("Pesel składa się z 11 cyfr!");
        }
        else if(!Regex.IsMatch(accountDto.Pesel, @"^\d+$") || !VerifyPesel(accountDto.Pesel))
        {
            throw new PeselValueException($"Upewnij się, że podałeś prawidłowy numer pesel: {accountDto.Pesel}");
        }


        return true;
    }

    private bool VerifyPesel(string pesel)
    {
        int[] multipliers = new int[11] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 7 };
        double sum = 0;

        for (int i = 0; i < pesel.Length - 1; i++)
        {
            sum += Char.GetNumericValue(pesel[i]) *multipliers[i];
        }

        int controlNumber = Convert.ToInt16(sum % 10);

        return controlNumber != 0 ?
            10 - controlNumber == Char.GetNumericValue(pesel[pesel.Length - 1]) :
            true;
    }

    private async Task<bool> IsEmailTaken(string email) => await _unitOfWork.UsersDetails.GetUserByEmail(email) != null;

    private async Task<bool> IsPeselTaken(string pesel) => await _unitOfWork.UsersDetails.GetUserByPesel(pesel) != null;

    private async Task<bool> IsUsernameTaken(string username) => await _unitOfWork.Users.GetUserByLogin(username) != null;

}