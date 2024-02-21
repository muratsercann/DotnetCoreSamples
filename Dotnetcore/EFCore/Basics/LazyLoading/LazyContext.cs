using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCore.Basics.LazyLoading
{
    public class LazyContext : DbContext
    {
        public DbSet<LazyLoading.LazyBlog> Blogs { get; set; }
        public DbSet<LazyLoading.LazyPost> Posts { get; set; }

        public LazyContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LazyBlog>().HasKey(blog => blog.BlogId);
            modelBuilder.Entity<LazyBlog>().HasMany(blog => blog.Posts).WithOne(post => post.Blog);

            modelBuilder.Entity<LazyPost>().HasKey(post => post.PostId);
            modelBuilder.Entity<LazyPost>().HasOne(post => post.Blog).WithMany(blog => blog.Posts).HasForeignKey(post => post.BlogId);
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
