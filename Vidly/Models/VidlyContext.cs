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

        // Seed initial data for Movies and Customers
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer  { Id = 1, Name = "Bob Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            );
        }




        // Constructor injection
        public VidlyContext(DbContextOptions<VidlyContext> options) : base(options)
        {
        }
    }
}
