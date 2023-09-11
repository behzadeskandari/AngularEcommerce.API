using Ecommerce.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ecommerce.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        //private readonly string connectionstring ;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //connectionstring = "Server=.;Database=ApiNet6CrudCompany;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(connectionstring);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Address>().HasKey(e => e.Id);
            //builder.Entity<Employee>().HasKey(e => e.Id);
            //builder.Entity<Team>().HasKey(e => e.Id);
            //builder.Entity<Job>().HasKey(e => e.Id);
            //builder.Entity<Employee>().HasOne(e => e.Address);
            //builder.Entity<Employee>().HasOne(e => e.job);

            //builder.Entity<Team>().HasMany(e => e.Employees).WithMany(e => e.Teams);


            base.OnModelCreating(builder);
        }

        public DbSet<Categories> categories { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Products> products { get; set; }


    }
}