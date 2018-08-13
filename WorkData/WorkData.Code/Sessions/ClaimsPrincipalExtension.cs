using System.Security.Claims;

namespace WorkData.Code.Sessions
{
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// GetClaimValue
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static string GetClaimValue(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal?.FindFirst(c => c.Type == claimType);

            return string.IsNullOrEmpty(claim?.Value) ? null : claim.Value;
        }
    }
}