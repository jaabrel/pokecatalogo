using pokecatalogo.Models;
using Microsoft.AspNetCore.Identity;

namespace pokecatalogo.Data.DbInitializerDev;

public class DbInitializer
{
    internal static async void Initialize(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();

        bool haAdicao = false;

        var newIdentityUsers = Array.Empty<IdentityUser>();
        var hasher = new PasswordHasher<IdentityUser>();

        if (dbContext.Users.Count() == 1)
        {
            newIdentityUsers =
            [
            ];
            await dbContext.Users.AddRangeAsync(newIdentityUsers);
            haAdicao = true;
        }

        try
        {
            if (haAdicao)
            {
                dbContext.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}