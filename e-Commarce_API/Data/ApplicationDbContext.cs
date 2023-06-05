using e_Commarce_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace e_Commarce_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                    new Brand
                    {
                        Id = 1,
                        Name = "Brand",
                        Slogan = "Brand Slogan",
                        Address = "Brand Address",
                        Phone = "0000000000",
                        Email = "brand@email.com",
                        ContactPerson = "Brand Contact Person",
                        NavLogo = "",
                        Logo = "",
                        IsShowNavLogo = false,
                        IsShowLogo = false
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
