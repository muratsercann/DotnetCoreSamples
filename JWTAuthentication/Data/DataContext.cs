using JWTAuthentication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace JWTAuthentication.Data;
public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }


}