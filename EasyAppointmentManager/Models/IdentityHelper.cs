using Microsoft.AspNetCore.Identity;

namespace EasyAppointmentManager.Models
{
    public static class IdentityHelper
    {
        public const string Employee = "Employee";
        public const string Customer = "Customer";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            // CreateRoles(null, "Employee", "Customer");

            RoleManager<IdentityRole>? roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


        }
    }
}
