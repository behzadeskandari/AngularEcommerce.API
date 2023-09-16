using Ecommerce.Common.Dtos.Address;
using Ecommerce.Common.Models;
using Ecommerce.Common.Statics;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(new List<Address>()
                    {
                        new Address()
                        {
                            Street = "Gisha Test address",
                            City = " Tehran",
                            Email = "behzad.b.i.g@gmail.com",
                            Phone = "02188260323",
                            Zip = "021"
                        },
                        new Address()
                        {
                            Street = "bamshad Test address",
                            City = " Rasht",
                            Email = "bamshad.b.i.g@gmail.com",
                            Phone = "022882670333",
                            Zip = "022"
                        },
                        new Address()
                        {

                            Street = "majid Test address",
                            City = "tabriz",
                            Email = "majid.b.i.g@gmail.com",
                            Phone = "022882670454",
                            Zip = "023"

                        }

                    });

                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Categories>()
                    {
                        new Categories()
                        {
                         Color = "red",
                         Icon = "fa-trash",
                         Image = "",
                         Name = "Shoes",
                        },
                        new Categories()
                        {

                         Color = "green",
                         Icon = "fa-email",
                         Image = "",
                         Name = "Pants",

                        },
                        new Categories()
                        {
                         Color = "yellow",
                         Icon = "fa-pen",
                         Image = "",
                         Name = "Hats",

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>()
                    {
                        new Employee()
                        {
                           Address = new Address(){ Street = "Gisha Test address", City = " Tehran",Email = "behzad.b.i.g@gmail.com",Phone = "02188260323",Zip = "021"},
                           FirstName = "behzad",
                           job = new Job(){  Name = "Programmer", Description = "Hard Work Behind Computer in long hours"},
                           LastName = "Eskandari"
                        },
                        new Employee()
                        {
                           Address = new Address(){ Street = "Gisha Test address", City = " Tehran",Email = "behzad.b.i.g@gmail.com",Phone = "02188260323",Zip = "021"},
                           FirstName = "hasan",
                           job = new Job(){  Name = "Accountant", Description = "Hard Work Behind Computer in long hours calculating math and ..."},
                           LastName = "Majidi"
                        },


                    });
                    context.SaveChanges();

                }

                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(new List<Job>()
                    {
                        new Job()
                        {
                            Name= "Programmer",
                            Description = "this is the Programmer description",



                        },
                        new Job()
                        {
                            Name= "CER",
                            Description = "this is the CEO description",

                        },

                    });
                    context.SaveChanges();

                }

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(new List<Orders>()
                    {
                        new Orders()
                        {
                           Country = "IRan",
                           City = "Tehran",
                           DateOrdered = DateTime.Now,
                           Phone = 02188260232,
                           ShippingAddress1 = "Gisha ave 29 number 23",
                           ShippingAddress2 = "Gisha ave 29 number 23",
                           Status = "Send",
                           TotalPrice = 20000,
                           Zip = "921",
                           
                           User = new ApplicationUser()
                           {
                               Id = "4",
                               FirstName = "behzad",
                               LastName = "Eskandari",
                               Email = "Behzad.b.i.g@gmail.com"
                           },
                           orderItem = new List<OrderItem>()
                           {
                               new OrderItem()
                               {
                                   Products = new Products()
                                   {
                                       
                                       Brand = "Nike",
                                       Category = new Categories()
                                       {
                                             Color = "red",
                                             Icon = "fa-trash",
                                             Image = "",
                                             Name = "Shoes",
                                         
                                       },
                                       CountInStock = 22,
                                       DateCreated = DateTime.Now,
                                       Description = "Description",
                                       Image = "",
                                       IsFeatured = true,
                                       Name ="Nike",
                                       Price = 12000,
                                       Rating = 3,
                                       RichDescription = "Rich Description",
                                   },
                                   Quantity = 22,

                               }
                           }
                        },


                    });
                    context.SaveChanges();

                }



                if (!context.OrderItem.Any())
                {
                    context.OrderItem.AddRange(new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Products = new Products()
                                {
                                    Id = 1,
                                },
                                Quantity = 22,
                            }
                        });

                    context.SaveChanges();

                }


                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Products>()
                        {
                            new Products()
                            {
                                Brand ="Nike",
                                Category = new Categories(){ Color = "red",Icon = "fa-trash",Id = 1,Image = "",Name = "Shoes" },
                                CountInStock = 2,
                                Description = "DEscription",
                                IsFeatured = true,
                                DateCreated = DateTime.Now,
                                Name = "Nike",
                                Price = 20000,
                                Rating = 4,
                                RichDescription = "Rich Decription Comes Later",
                                Image = "",

                            },

                        });

                    context.SaveChanges();

                }
            }
        }


        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles Section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //User
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "behzad.b.i.g@gmail.com";
                var adminuser = await userManager.FindByNameAsync(adminUserEmail);

                if (adminuser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Id = 5.ToString(),
                        FirstName = "behzad ",
                        LastName = "eskandari",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        SecurityStamp = DateTime.Now.ToString(),
                    };
                    await userManager.CreateAsync(newAdminUser, "coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //simple User 
                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newappUser = new ApplicationUser()
                    {
                        Id = 6.ToString(),
                        FirstName = "Application User",
                        LastName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        SecurityStamp = DateTime.Now.ToString(),
                    };

                    await userManager.CreateAsync(newappUser, "coding@1234?");
                    await userManager.AddToRoleAsync(newappUser, UserRoles.User);
                }

            }

        }
    }

}