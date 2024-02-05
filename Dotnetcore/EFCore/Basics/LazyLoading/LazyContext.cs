using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace EFCore.Basics.LazyLoading
{
    public class LazyContext : DbContext
    {
        public DbSet<LazyBlog> Blogs { get; set; }
        public DbSet<LazyPost> Posts { get; set; }

        public LazyContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder
                .UseSqlServer(connectionString);

            Console.WriteLine("---------");
            Console.WriteLine($"Connection String : {connectionString}");
            Console.WriteLine("---------");
        }
    }
}
