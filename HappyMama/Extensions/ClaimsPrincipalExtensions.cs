using System.Security.Claims;

namespace HappyMama.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id (this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
