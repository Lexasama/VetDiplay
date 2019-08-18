using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace VetDisplay.Authentication
{
    public abstract class AuthenticationManager<TConfigInfo>
    {
        public async Task OnCreatingTicket(OAuthCreatingTicketContext ctx)
        {
            TConfigInfo configInfo = await GetConfigInfoFromContext(ctx);
            await CreateOrUpdateUser(configInfo);
            ConfigData config = await FindUser(configInfo);
            ctx.Principal = CreatePrincipal(config);
        }

        protected abstract Task<TConfigInfo> GetConfigInfoFromContext(OAuthCreatingTicketContext ctx);

        protected abstract Task CreateOrUpdateUser(TConfigInfo userInfo);

        protected abstract Task<ConfigData> FindUser(TConfigInfo userInfo);

        ClaimsPrincipal CreatePrincipal(ConfigData user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim( ClaimTypes.NameIdentifier, user.ConfigId.ToString(), ClaimValueTypes.String ),
                new Claim( ClaimTypes.Email, user.Email )
            };
            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthentication.AuthenticationType, ClaimTypes.Email, string.Empty));
            return principal;
        }
    }
}
