using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data.DB;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(@"Data Source=D:\Desktop\Programming\C# programming\Product and Category API\Infrastructure\app.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
