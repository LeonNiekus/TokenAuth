using Case_SB_Domain;
using Case_SB_Web.Repository;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Case_SB_Web.ServiceProviders
{
    public class SBAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.SetError("invalid_client", "Authorization header could not provide valid client credentials.");
                context.Rejected();
                return;
            }

            Client client = (new ClientRepository()).ValidateClient(clientId, clientSecret);

            if (client != null)
            {
                context.OwinContext.Set<Client>("oauth:client", client);
                context.Validated(clientId);
            }
            else
            {
                context.SetError("invalid_client", "These client credentials do not match our records.");
                context.Rejected();
            }

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