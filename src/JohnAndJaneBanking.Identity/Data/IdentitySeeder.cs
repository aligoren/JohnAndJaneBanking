using JohnAndJaneBanking.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace JohnAndJaneBanking.Identity.Data;

public class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await SeedRolesAsync(roleManager);
        await SeedUsersAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var role = new IdentityRole("Admin");
            await roleManager.CreateAsync(role);
        }

        if (!await roleManager.RoleExistsAsync("Customer"))
        {
            var role = new IdentityRole("Customer");
            await roleManager.CreateAsync(role);
        }
    }

    private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
    {
        if (await userManager.FindByEmailAsync("admin@bank.com") == null)
        {
            var user = new ApplicationUser
            {
                Email = "admin@bank.com",
                UserName = "admin@bank.com",
                FirstName = "Admin",
                LastName = "User",
            };

            var result = await userManager.CreateAsync(user, "AdminPass123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}