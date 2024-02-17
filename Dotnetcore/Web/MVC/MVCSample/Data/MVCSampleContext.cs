using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCSample.Models;

namespace MVCSample.Data
{
    public class MVCSampleContext : DbContext
    {
        public MVCSampleContext (DbContextOptions<MVCSampleContext> options)
            : base(options)
        {
        }

        public DbSet<MVCSample.Models.Movie> Movie { get; set; } = default!;
    }
}
