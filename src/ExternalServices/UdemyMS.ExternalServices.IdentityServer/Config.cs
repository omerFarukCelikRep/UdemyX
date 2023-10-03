﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using UdemyMS.Common.Utilities;

namespace UdemyMS.ExternalServices.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.Email(),
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource
        {
            Name = "roles",
            DisplayName = "Roles",
            Description = "Kulanıcı Rolleri",
            UserClaims = new[] {"role"}
        },
    };

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource(Constants.IdentityServer.Resources.Catalog){Scopes = { Constants.IdentityServer.Permissions.Catalog } },
        new ApiResource(Constants.IdentityServer.Resources.PhotoStock){Scopes = { Constants.IdentityServer.Permissions.PhotoStock } },
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope(Constants.IdentityServer.Permissions.Catalog,"Catalog Api Tam Erişim"),
        new ApiScope(Constants.IdentityServer.Permissions.PhotoStock,"Photo Stock Api Tam Erişim"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client
        {
            ClientId = "WebMvcClient",
            ClientName = "Asp.Net Core MVC",
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes =
            {
                Constants.IdentityServer.Permissions.Catalog,
                Constants.IdentityServer.Permissions.PhotoStock,
                IdentityServerConstants.LocalApi.ScopeName
            }
        },
        new Client
        {
            ClientId = "WebMvcClientForUser",
            ClientName = "Asp.Net Core MVC",
            AllowOfflineAccess = true,
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OfflineAccess,
                IdentityServerConstants.LocalApi.ScopeName,
                "roles"
            },
            AccessTokenLifetime = 1*60*60,
            RefreshTokenExpiration = TokenExpiration.Absolute,
            AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60) - DateTime.Now).TotalSeconds,
            RefreshTokenUsage = TokenUsage.ReUse
        }
    };
}
