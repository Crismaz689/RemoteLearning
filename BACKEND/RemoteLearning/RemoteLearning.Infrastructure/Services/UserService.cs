namespace RemoteLearning.Application.Services;

public class UserService : IUserService
{
    private const int PASSWORD_LENGTH = 12;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IEmailService emailService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
        _mapper = mapper;
    }

    public async Task<User> CreateUser(CreateAccountDto accountDto)
    {
        if (await IsEmailTaken(accountDto.Email))
        {
            throw new EnteredEmailTakenException($"Na {accountDto.Email} jest już założone konto w serwisie!");
        }

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
            await _emailService.SendCredentials(user.Username ?? "", password, userDetails.Email);
        }

        return user;
    }

    public async Task<User> Login(LoginDto loginDto)
    {
        var user = await _unitOfWork.Users.GetUserByLogin(loginDto.Username);

        if (user == null)
        {
            throw new EnteredInvalidUsernameException("Wprowadzono błędną nazwę użytkownika!");
        }

        using (var hmac = new HMACSHA512(user.PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (!computedHash.Equals(user.PasswordHash))
            {
                throw new EnteredInvalidPasswordException("Wprowadzono błędne hasło!");
            }

            return user;
        }
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

    private async Task<bool> IsEmailTaken(string email)
    {
        return await _unitOfWork.UsersDetails.GetUserByEmail(email) != null;
    }

    private async Task<bool> IsUsernameTaken(string username)
    {
        return await _unitOfWork.Users.GetUserByLogin(username) != null;
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
}