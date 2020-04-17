using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using DailyReports.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;

namespace DailyReports.Providers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userRepo = new UserRepository();

            var userDetails = userRepo.GetUserDetails(context.UserName, context.Password);
            if (userDetails == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var passwordhash = DecodePassword(userDetails.Password);
            if (context.Password != passwordhash)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim("IsAdmin", userDetails.IsAdmin.ToString(), ClaimValueTypes.Boolean));
                identity.AddClaim(new Claim("UserId", userDetails.Id.ToString(), ClaimValueTypes.Integer32));
                //identity.AddClaim(new Claim("RoleId", roleId.ToString(), ClaimValueTypes.String));
                var userInfo = new Dictionary<string, string>
                {
                    {
                        "user", JsonConvert.SerializeObject(new
                        {
                            userDetails.Username,
                            userDetails.Email
                        })
                    }
                };

                ValidateIdentity(userInfo, context, identity);
              
            }
        }

        private void ValidateIdentity(Dictionary<string, string> userInfo, OAuthGrantResourceOwnerCredentialsContext context, ClaimsIdentity identity)
        {
            var props = new AuthenticationProperties(userInfo);

            var ticket = new AuthenticationTicket(identity, props);

            context.Validated(ticket);
        }

        private string DecodePassword(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder decodedCode = encoder.GetDecoder();
            byte[] decodedBydeCode = Convert.FromBase64String(encodedData);
            int charCount = decodedCode.GetCharCount(decodedBydeCode, 0, decodedBydeCode.Length);
            char[] decodedChar = new char[charCount];
            decodedCode.GetChars(decodedBydeCode, 0, decodedBydeCode.Length, decodedChar, 0);
            string result = new String(decodedChar);
            return result;
        }
    }
}