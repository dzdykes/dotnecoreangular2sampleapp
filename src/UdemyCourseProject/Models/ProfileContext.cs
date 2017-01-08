using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCourseProject.Models
{
    public class ProfileContext:IdentityDbContext<ApplicationUser>
    {
        public ProfileContext(DbContextOptions<ProfileContext> options):base(options)
        {

        }

        public ProfileContext()
        {

        }

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Hobby> Hobby { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Individual>().ToTable("Individual");
            builder.Entity<Organization>().ToTable("Organization");
            builder.Entity<Hobby>().ToTable("Hobby");
        }
    }
}
