using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MultiAuthScheme.ResourceServer.Authentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyOptions>
    {
        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result = AuthenticateResult.NoResult();

            if (Request.Headers.TryGetValue(ApiKeyOptions.RequestHeaderName, out var authHeaderValue))
            {
                if (authHeaderValue.ToString() == "4426f638-ccba-4e03-8b62-78addc3cad48")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, "John Doe", ClaimValueTypes.String, ClaimsIssuer),
                        new Claim(ClaimTypes.Name, "John Doe", ClaimValueTypes.String, ClaimsIssuer)
                    };

                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, ApiKeyOptions.AuthenticationScheme));

                    result = AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, ApiKeyOptions.AuthenticationScheme));
                }
                else
                {
                    result = AuthenticateResult.Fail("Invalid API key");
                }
            }

            return Task.FromResult(result);
        }
    }
}
