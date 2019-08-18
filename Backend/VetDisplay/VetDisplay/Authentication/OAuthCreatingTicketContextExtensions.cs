using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace VetDisplay.Authentication
{
    public static class OAuthCreatingTicketContextExtensions
    {
        public static string GetEmail(this OAuthCreatingTicketContext @this)
        {
            return @this.Identity.FindFirst(c => c.Type == ClaimTypes.Email).Value;
        }
    }
}
