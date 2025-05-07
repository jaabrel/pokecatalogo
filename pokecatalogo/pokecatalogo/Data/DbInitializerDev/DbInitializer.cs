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
        
        
    }
}