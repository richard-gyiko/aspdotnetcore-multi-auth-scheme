using Microsoft.AspNetCore.Authentication;

namespace MultiAuthScheme.ResourceServer.Authentication
{
    public class ApiKeyOptions : AuthenticationSchemeOptions
    {
        public static readonly string RequestHeaderName = "Api-Key";
        public static readonly string AuthenticationScheme = "ApiKey";
    }
}
