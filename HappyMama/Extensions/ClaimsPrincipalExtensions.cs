using System.Security.Claims;
using static HappyMama.BusinessLogic.Constants.RoleConstants;

namespace HappyMama.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id (this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin (this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}
