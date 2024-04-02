using Microsoft.AspNetCore.Identity;
using static HappyMama.BusinessLogic.Constants.RoleConstants;
namespace Microsoft.AspNetCore.Builder
{
	public static class ApplicationBuilderExtensions
	{
		public static async Task AddAdminRoleAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();

			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			if (userManager != null && roleManager != null && !await roleManager.RoleExistsAsync(AdminRole))
			{
				var role = new IdentityRole(AdminRole);
				await roleManager.CreateAsync(role);

				var admin = await userManager.FindByEmailAsync("admin@abv.bg");

				if (admin != null)
				{
					await userManager.AddToRoleAsync(admin, role.Name);
				}
			}
		}
	}
}
