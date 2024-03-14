namespace ProjectHub.Blazor.Factories;

using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using ProjectHub.Blazor.Models;

public class CustomAccountFactory : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    public CustomAccountFactory(IAccessTokenProviderAccessor accessor)
        : base(accessor)
    {
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(CustomUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        ClaimsPrincipal? initialUser = await base.CreateUserAsync(account, options);
        if (initialUser.Identity is { IsAuthenticated: true })
        {
            ClaimsIdentity? userIdentity = (ClaimsIdentity)initialUser.Identity;
            foreach (string role in account.Roles)
            {
                userIdentity.AddClaim(new Claim("appRole", role));
            }
        }

        return initialUser;
    }
}