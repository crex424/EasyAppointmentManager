using Microsoft.AspNetCore.Identity;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Helper class for identity
    /// </summary>
    public static class IdentityHelper
    {
        public const string Employee = "Employee";
        public const string Customer = "Customer";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            // CreateRoles(null, "Employee", "Customer");

            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        /// <summary>
        /// A method that creates a default user
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            // If no users are present, make the default user
            if (numUsers == 0) { // If no users are in the specified role
                var defaultUser = new IdentityUser()
                {
                    Email = "employee@medclinic.com",
                    UserName = "Admin"
                };

                await userManager.CreateAsync(defaultUser, "Cpw22!");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}
