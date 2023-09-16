using Ecommerce.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Net;

namespace Ecommerce.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private readonly string connectionstring ;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            connectionstring = "Server=.;Database=AngularEcommerce;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().HasKey(e => e.Id);
            builder.Entity<Categories>(e =>
            {
                e.HasKey(e => e.Id);
                
                
            });
            
            builder.Entity<OrderItem>(e =>
            {
                e.HasOne(x => x.Products);
                e.HasKey(e => e.Id);
            });

            builder.Entity<Orders>(e =>
            {
                e.HasMany(e => e.orderItem);
                e.HasKey(e => e.Id);
                e.HasOne(e => e.User);
            });
            
            builder.Entity<Products>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasOne(e => e.Category);
            });

            builder.Entity<ShoppingCartItem>(e =>
            {
                e.HasMany(e => e.products);
                e.HasKey(e => e.Id);
            });

            builder.Entity<Address>().HasKey(e => e.Id);
            builder.Entity<Employee>().HasKey(e => e.Id);
            builder.Entity<Team>().HasKey(e => e.Id);
            builder.Entity<Job>().HasKey(e => e.Id);
            builder.Entity<Employee>().HasOne(e => e.Address);
            builder.Entity<Employee>().HasOne(e => e.job);

            builder.Entity<Team>().HasMany(e => e.Employees).WithMany(e => e.Teams);


            base.OnModelCreating(builder);
        }

        //Order Products And Categories Sets 
        public DbSet<Categories> Categories { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        //public DbSet<ApplicationUser> AppUsers { get; set; }
        //Team And Jobs Sets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Job> Jobs { get; set; }

    }
}