/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using static AspNet.Security.OAuth.TikTok.TikTokAuthenticationConstants;

namespace AspNet.Security.OAuth.TikTok
{
    /// <summary>
    /// Defines a set of options used by <see cref="TikTokAuthenticationHandler"/>.
    /// </summary>
    public class TikTokAuthenticationOptions : OAuthOptions
    {
        public TikTokAuthenticationOptions()
        {
            ClaimsIssuer = TikTokAuthenticationDefaults.Issuer;
            CallbackPath = TikTokAuthenticationDefaults.CallbackPath;

            AuthorizationEndpoint = TikTokAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = TikTokAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = TikTokAuthenticationDefaults.UserInformationEndpoint;

            Scope.Add("user.info.basic");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "open_id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "display_name");
            ClaimActions.MapJsonKey(Claims.Avatar, "avatar");
        }

        /// <summary>
        /// Gets the list of list of fields and edges to retrieve from the user information endpoint.
        /// </summary>
        public ISet<string> Fields { get; } = new HashSet<string>()
        {
            "open_id",
            "display_name",
        };
    }
}
