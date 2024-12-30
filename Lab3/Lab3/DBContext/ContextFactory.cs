using Lab3.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab3.DBContext
{
    public class ContextFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("SQL");
            var optionsBuilder = new DbContextOptionsBuilder<AccountDbContext>();
            DbContextOptions<AccountDbContext> options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            return new AccountDbContext(optionsBuilder.Options);
        }
    }
}
