using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace EFCore.Basics.LazyLoading
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext()
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
