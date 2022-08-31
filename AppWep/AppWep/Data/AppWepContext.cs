using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppWep.Models;

namespace AppWep.Data
{
    public class AppWepContext : DbContext
    {
        public AppWepContext (DbContextOptions<AppWepContext> options)
            : base(options)
        {
        }

        public DbSet<AppWep.Models.Employee> Employee { get; set; } = default!;
    }
}
