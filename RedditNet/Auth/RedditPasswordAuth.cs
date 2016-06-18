using System;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace RedditNet.Auth
{
    public class RedditPasswordAuth : RedditAuth
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public RedditPasswordAuth(string clientId, string clientSecret, string redirectUri, string username, string password) 
            : base(clientId, clientSecret, redirectUri)
        {
            Username = username;
            Password = password;
        }

        public override async Task GetOAuthTokenAsync()
        {
            TokenResponse resp = await TokenClient.RequestResourceOwnerPasswordAsync(Username, Password, 
                extra: new { redirect_uri = RedirectUri }).ConfigureAwait(false);

            if (resp.IsError)
                throw new Exception(resp.IsHttpError ? resp.HttpErrorReason : resp.Error);

            if (resp.ExpiresIn > 0)
                ExpireTime = DateTime.UtcNow.AddSeconds(resp.ExpiresIn);

            AccessToken = resp.AccessToken;
        }
    }
}
