using dragon.Models;
using Microsoft.AspNetCore.Identity;

namespace dragon.Data
{
    public class IdentitySeedData
    {
        public static async Task Initialize(dragonContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminRole = "Admin";
            string memberRole = "member";
            string password4all = "Pa$$w0rd";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));

            }

            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }

            if (await userManager.FindByNameAsync("email1@email.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    FirstName = "email1",
                    LastName = "email",
                    Address = "test",
                    City = "test",


                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            if (await userManager.FindByNameAsync("member@member.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "member@member.com",
                    Email = "member@member.com",
                    FirstName = "member1",
                    LastName = "member",
                    Address = "test",
                    City = "test",
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, memberRole);
                }
            }
        }
    }
}
