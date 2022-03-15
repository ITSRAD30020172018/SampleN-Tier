using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace SampleWebAPI.Data
{
    public class ApplicationDbSeeder
    {
        private readonly ApplicationDbContext _ctx;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationDbSeeder(ApplicationDbContext ctx, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
            
        }
        public async Task Seed()
        {
            // Seed the Main User
            Random r = new Random();
            if (_ctx.Users.Count() == 0)
            {
                List<ApplicationUser> UserSeeds = new List<ApplicationUser> {
                            new ApplicationUser
                                {
                                    Fname = "Paul",
                                    SecondName = "Powell",
                                    UserName = "powell.paul@itsligo.ie",
                                    Email = "powell.paul@itsligo.ie",
                                    EmailConfirmed = true,
                                    SecurityStamp = Guid.NewGuid().ToString()
                                },
                            };
               
                // Create all Users with the same password
                foreach (ApplicationUser user in UserSeeds)
                {
                    var result = await _userManager.CreateAsync(user, "Rad302$1");

                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create user in Seeding");
                    }
                }
                _ctx.SaveChanges();

               
            }
            if (_ctx.Roles.Count() < 1)
            {
                await _roleManager.CreateAsync(
                    new IdentityRole { Id = Guid.NewGuid().ToString(), 
                        Name = "Widget Manager" });
            }
            
            _ctx.SaveChanges();

            ApplicationUser ppowell = await _userManager.FindByNameAsync("powell.paul@itsligo.ie");
            if (ppowell != null)
            {
                
                var roles = await _userManager.GetRolesAsync(ppowell);
                if (roles.Count < 1)
                {
                    var result = await _userManager.AddToRoleAsync(ppowell, "Widget Manager");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could add user to Admin Role");
                    }

                }
            }
            _ctx.SaveChanges();

        }
    }
}

