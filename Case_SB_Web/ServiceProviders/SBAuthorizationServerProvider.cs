using Case_SB_Domain;
using Case_SB_Web.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Case_SB_Web.ServiceProviders
{
    public class SBAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserRepository _users = new UserRepository())
            {
                User user = _users.ValidateUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The provided name and password match does not exist in our records.");
                    return;
                }

                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                identity.AddClaim(new Claim("Email", user.Email));

                context.Validated(identity);
            }
        }
    }
}