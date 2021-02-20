using System.Security.Claims;
using System.Security.Principal;

namespace Planinarenje.Models
{
    public static class IdentityExtensionsMore
    {
        public static string GetRealUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("RealUserName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetImage(this IIdentity identity)
        {
             
            var claim = ((ClaimsIdentity)identity).FindFirst("UserImage");
            
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserID(this IIdentity identity)
        {

            var claim = ((ClaimsIdentity)identity).FindFirst("UserID");

            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        

    }
}