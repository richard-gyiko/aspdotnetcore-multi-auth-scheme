using Microsoft.AspNetCore.Authentication;
using System;

namespace MultiAuthScheme.ResourceServer.Authentication
{
    public static class ApiKeyAuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder authenticationBuilder, Action<ApiKeyOptions> configureOptions = null)
        {
            authenticationBuilder.AddScheme<ApiKeyOptions, ApiKeyAuthenticationHandler>(ApiKeyOptions.AuthenticationScheme, "API Key Authentication Scheme", configureOptions);

            return authenticationBuilder;
        }
    }
}
