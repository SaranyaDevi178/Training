using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheckingWebApiEndpoint.Models;

namespace CheckingWebApiEndpoint.Data
{
    public class CheckingWebApiEndpointContext : DbContext
    {
        public CheckingWebApiEndpointContext (DbContextOptions<CheckingWebApiEndpointContext> options)
            : base(options)
        {
        }

        public DbSet<CheckingWebApiEndpoint.Models.Product> Product { get; set; } = default!;
    }
}
