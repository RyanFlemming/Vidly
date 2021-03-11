using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Models
{
    public class VidlyContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        // Constructor injection
        public VidlyContext(DbContextOptions<VidlyContext> options) : base(options)
        {
        }
    }
}
