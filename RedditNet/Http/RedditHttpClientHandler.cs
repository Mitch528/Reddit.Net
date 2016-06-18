using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using RedditNet.Auth;

namespace RedditNet.Http
{
    public class RedditHttpClientHandler : HttpClientHandler
    {
        public const string RateLimitUsedHeader = "X-Ratelimit-Used";
        public const string RateLimitRemainingHeader = "X-Ratelimit-Remaining";
        public const string RateLimitResetHeader = "X-Ratelimit-Reset";

        public int LimitUsed { get; private set; }

        public int LimitRemaining { get; private set; }

        public DateTime? LimitReset { get; private set; }

        public RedditAuth Auth { get; set; }

        public RedditHttpClientHandler(RedditAuth auth)
        {
            Auth = auth;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (LimitRemaining == 0 && LimitReset.HasValue)
            {
                TimeSpan timeLeft = LimitReset.Value - DateTime.UtcNow;

                if (timeLeft > TimeSpan.Zero)
                    await Task.Delay(timeLeft, cancellationToken).ConfigureAwait(false);
            }

            if (Auth != null)
            {
                string token = Auth.AccessToken;

                if (string.IsNullOrEmpty(token) || (Auth.ExpireTime.HasValue && DateTime.UtcNow > Auth.ExpireTime.Value))
                {
                    await Auth.GetOAuthTokenAsync().ConfigureAwait(false);

                    token = Auth.AccessToken;
                }

                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            HttpResponseMessage resp = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            IEnumerable<string> limitUsed;
            IEnumerable<string> limitRemaining;
            IEnumerable<string> limitReset;

            if (resp.Headers.TryGetValues(RateLimitUsedHeader, out limitUsed) &&
                resp.Headers.TryGetValues(RateLimitRemainingHeader, out limitRemaining) &&
                resp.Headers.TryGetValues(RateLimitResetHeader, out limitReset))
            {
                LimitUsed = int.Parse(limitUsed.FirstOrDefault());
                LimitRemaining = (int)double.Parse(limitRemaining.FirstOrDefault());
                LimitReset = DateTime.UtcNow.AddSeconds(int.Parse(limitReset.FirstOrDefault()));
            }

            return resp;
        }
    }
}
