using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Reddit.Net.Auth
{
    public abstract class RedditAuth
    {
        public const string RedditAccessTokenUrl = "https://www.reddit.com/api/v1/access_token";
        public const string RedditAuthorizeUrl = "https://reddit.com/api/v1/authorize";

        protected readonly TokenClient TokenClient;

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        public string RedirectUri { get; private set; }

        public string AccessToken { get; protected set; }

        public DateTime? ExpireTime { get; protected set; }

        protected RedditAuth(string clientId, string redirectUri)
        {
            TokenClient = new TokenClient(RedditAccessTokenUrl, clientId);

            ClientId = clientId;
            RedirectUri = redirectUri;
        }

        protected RedditAuth(string clientId, string clientSecret, string redirectUri)
        {
            TokenClient = new TokenClient(RedditAccessTokenUrl, clientId, clientSecret);

            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        public abstract Task GetOAuthTokenAsync();
    }
}
