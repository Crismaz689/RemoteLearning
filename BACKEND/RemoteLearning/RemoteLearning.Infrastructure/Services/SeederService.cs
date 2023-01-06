namespace RemoteLearning.Infrastructure.Services;

public class SeederService : ISeederService
{
    private readonly IUnitOfWork _unitOfWork;

    public SeederService(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

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

    public async Task<bool> SeedCategories()
    {
        var categories = await _unitOfWork.Categories.GetAll();

        if (categories.Any())
        {
            return false;
        }

        var categoriesData = await System.IO.File.ReadAllTextAsync("../RemoteLearning.Infrastructure/Helpers/SeederSources/categories.json");
        var categoriesToInsert = JsonSerializer.Deserialize<List<Category>>(categoriesData);

        categoriesToInsert!.ForEach((category) =>
        {
            _unitOfWork.Categories.Create(category);
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

    public void CreateTriggers(IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<RemoteLearningDbContext>();
            using (StreamReader sr = new StreamReader("../RemoteLearning.Infrastructure/Helpers/StoredProcedures/DeleteUpdateTestTimeCreation.sql"))
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sr.ReadToEnd();
                context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                context.Database.CloseConnection();
            }

            using (StreamReader sr = new StreamReader("../RemoteLearning.Infrastructure/Helpers/StoredProcedures/DeleteUpdateTestTimeDeletion.sql"))
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sr.ReadToEnd();
                context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                context.Database.CloseConnection();
            }

            using (StreamReader sr = new StreamReader("../RemoteLearning.Infrastructure/Helpers/StoredProcedures/DeleteUpdateTestTimeUpdate.sql"))
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sr.ReadToEnd();
                context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                context.Database.CloseConnection();
            }

            using (StreamReader sr = new StreamReader("../RemoteLearning.Infrastructure/Helpers/StoredProcedures/CreateUpdateTestTimeCreation.sql"))
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sr.ReadToEnd();
                context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                context.Database.CloseConnection();
            }

            using (StreamReader sr = new StreamReader("../RemoteLearning.Infrastructure/Helpers/StoredProcedures/CreateUpdateTestTimeDeletion.sql"))
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sr.ReadToEnd();
                context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                context.Database.CloseConnection();
            }

            using (StreamReader sr = new StreamReader("../RemoteLearning.Infrastructure/Helpers/StoredProcedures/CreateUpdateTestTimeUpdate.sql"))
            {
                var cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sr.ReadToEnd();
                context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
                context.Database.CloseConnection();
            }
        }
    }
}
