namespace RemoteLearning.Infrastructure.Services;

public class SeederService : ISeederService
{
    private readonly IUnitOfWork _unitOfWork;

    public SeederService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> SeedRoles()
    {
        var roles = await _unitOfWork.Roles.GetAll();

        if (roles.Any())
        {
            return false;
        }

        var rolesData = await System.IO.File.ReadAllTextAsync("../RemoteLearning.Infrastructure/Helpers/SeederSources/roles.json");
        var rolesToInsert = JsonSerializer.Deserialize<List<Role>>(rolesData);

        rolesToInsert!.ForEach((role) =>
        {
            _unitOfWork.Roles.Create(role);
        });

        return await _unitOfWork.SaveChangesAsync() != 0;
    }

    public async Task<bool> SeedAccounts()
    {
        var users = await _unitOfWork.Users.GetAll();
        var usersDetails = await _unitOfWork.UsersDetails.GetAll();

        if (users.Any() || usersDetails.Any())
        {
            return false;
        }

        var usersData = await System.IO.File.ReadAllTextAsync("../RemoteLearning.Infrastructure/Helpers/SeederSources/accounts.json");
        var usersToInsert = JsonSerializer.Deserialize<List<User>>(usersData);

        usersToInsert!.ForEach((user) =>
        {
            using (var hmac = new HMACSHA512())
            {
                user.Username = user.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123"));
                user.PasswordSalt = hmac.Key;

                _unitOfWork.Users.Create(user);
            }
        });

        return await _unitOfWork.SaveChangesAsync() != 0;
    }
}
