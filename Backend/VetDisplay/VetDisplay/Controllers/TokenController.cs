using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VetDisplay.DAL;
using VetDisplay.Authentication;
using VetDisplay.Services;
using Microsoft.AspNetCore.Mvc;

namespace VetDisplay.WebApp.Controllers
{
    [Route("/api/[controller]")]
    public class TokenController : Controller
    {
        readonly ConfigGateway _configGateway;
        readonly TokenService _tokenService;

        public TokenController( ConfigGateway configGateway, TokenService tokenService)
        {
            _configGateway = configGateway;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Token()
        {
            var identity = User.Identities.SingleOrDefault(i => i.AuthenticationType == CookieAuthentication.AuthenticationScheme);
            if (identity == null) return Ok(new { Success = false });

            string configId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            string email = identity.FindFirst(ClaimTypes.Email).Value;
            Token token = _tokenService.GenerateToken(configId, email);
            IEnumerable<string> providers = await _configGateway.GetAuthenticationProviders(configId);
            return Ok(new { Success = true, Bearer = token, Email = email, BoundProviders = providers });
        }
    }
}
