using Tiffin.Data.Static;
using Tiffin.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiffin.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                
                if (!context.Cooks.Any())
                {
                    context.Cooks.AddRange(new List<Cook>()
                    {
                        new Cook()
                        {
                            Name = "Gordon Ramsay",
                            ImageURL = "https://i.postimg.cc/pdBnG8PD/Gordon-Ramsay.jpg",
                            Description = "This is the description of the first cook"
                        },
                        new Cook()
                        {
                            Name = "Jamie Oliver",
                            ImageURL = "https://i.postimg.cc/FH3SS8qC/Jamie-Oliver.jpg",
                            Description = "This is the description of the first cook"
                        },
                        new Cook()
                        {
                            Name = "Bobby Flay",
                            ImageURL = "https://i.postimg.cc/1tCVPQnX/Bobby-Flay.jpg",
                            Description = "This is the description of the first cook"
                        },
                        new Cook()
                        {
                            Name = "Wolfgang Puck",
                            ImageURL = "https://i.postimg.cc/T2s54TvH/Wolfgang-Puck.jpg",
                            Description = "This is the description of the first cook"
                        },
                        new Cook()
                        {
                            Name = "Santosh Shah",
                            ImageURL = "https://i.postimg.cc/Y0vGCsY3/santosh-shah.jpg",
                            Description = "This is the description of the first cook"
                        },
                    });
                    context.SaveChanges();
                }
                
               
                //Movies
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Biryani",
                            Description = "This is the Biryani",
                            Price = 39.50,
                            ImageURL = "https://i.postimg.cc/LX22ZTNd/Biryani.jpg",
                          
                            CookId = 1,

                            ProductCategory = ProductCategory.Dinner_Launch
                        },
                        new Product()
                        {
                            Name = "AppleJuice",
                            Description = "This is the Apple Juice",
                            Price = 29.50,
                            ImageURL = "https://i.postimg.cc/LhdX66H9/Apple-Juice.jpg",
                       
                            CookId = 2,
                            
                            ProductCategory = ProductCategory.Juice
                        },
                        new Product()
                        {
                            Name = "Tiramisu",
                            Description = "This is the Tiramisu",
                            Price = 29.50,
                            ImageURL = "https://i.postimg.cc/T2KJw7RF/Tiramisu.jpg",

                            CookId = 4,

                            ProductCategory = ProductCategory.Desert
                        },
                        new Product()
                        {
                            Name = "Plain Dosa",
                            Description = "This is the Plain Dosa",
                            Price = 39.50,
                            ImageURL = "https://i.postimg.cc/XqtZGkg0/Dosa.jpg",
                           
                            CookId = 3,

                            ProductCategory = ProductCategory.Breakfast
                        },
                       
                        new Product()
                        {
                            Name = "Texmex Salad",
                            Description = "This is the Texmex Salad",
                            Price = 39.50,
                            ImageURL = "https://i.postimg.cc/J0XXQF0h/Texmex-Salad.jpg",
                            
                            CookId = 5,

                            ProductCategory = ProductCategory.Salad
                        },
                       
                    });
                    context.SaveChanges();
                }
                
               
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "@Hello");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "@Hello");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
