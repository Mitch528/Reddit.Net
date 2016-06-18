using System.Threading.Tasks;
using IdentityModel.Client;
using RedditNet.Extensions;

namespace RedditNet.Auth
{
    public class RedditImplictAuth : RedditAuth
    {
        public RedditImplictAuth(string clientId, string redirectUri, string token) : base(clientId, redirectUri)
        {
            AccessToken = token;
        }

        public override Task GetOAuthTokenAsync()
        {
            return Task.FromResult(false);
        }

        public static string GetAuthUrl(string clientId, string state, string redirectUri, string responseType,
            RedditScope scopes, bool permanent = false)
        {
            var scopesList = typeof(RedditScope).EnumToList((int)scopes);

            return new AuthorizeRequest(RedditAuthorizeUrl).CreateAuthorizeUrl(clientId, responseType, string.Join(" ", scopesList),
                state: state, redirectUri: redirectUri, extra: new { duration = permanent ? "permanent" : "temporary" });
        }
    }
}
