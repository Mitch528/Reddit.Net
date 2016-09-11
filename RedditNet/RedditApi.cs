using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedditNet.Auth;
using RedditNet.Constants;
using RedditNet.Extensions;
using RedditNet.Http;
using RedditNet.Json;
using RedditNet.Requests;
using RedditNet.Things;
using RedditNet.Utils;

namespace RedditNet
{
    public class RedditApi
    {
        private readonly RedditHttpClientHandler _clientHandler;

        public JsonSerializerSettings SerializerSettings { get; }

        public HttpClient Client { get; set; }

        public int RequestLimitUsed => _clientHandler.LimitUsed;

        public int RequestLimitRemaining => _clientHandler.LimitRemaining;

        public DateTime? RequestLimitReset => _clientHandler.LimitReset;

        public RedditApi(RedditHttpClientHandler clientHandler = null) : this(UrlConstants.RedditBaseUrl, clientHandler)
        {
        }

        public RedditApi(RedditAuth auth) : this(UrlConstants.RedditBaseOAuthApiUrl, new RedditHttpClientHandler(auth))
        {
        }

        protected RedditApi(string url, RedditHttpClientHandler clientHandler)
        {
            _clientHandler = clientHandler;

            Client = new HttpClient(_clientHandler) { BaseAddress = new Uri(url) };
            Client.DefaultRequestHeaders.Add("User-Agent", "RedditNET/1.0 (by /u/mitch528)");

            SerializerSettings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new ThingConverter(this)
                }
            };
        }

        #region Accounts
        public Task<Account> GetMeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetAsync<Account>(UrlConstants.MeUrl, cancellationToken: cancellationToken);
        }

        public Task<UserPreferences> GetPreferencesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetAsync<UserPreferences>(UrlConstants.MePrefsUrl, cancellationToken: cancellationToken);
        }

        public Task UpdateUserPrefsAsync(UserPreferences newPrefs,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return PatchAsync(UrlConstants.MePrefsUrl, newPrefs, cancellationToken);
        }
        #endregion

        #region Private Messages

        public Task<Listing> GetMessagesAsync(MessageRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string url;
            switch (request.Type)
            {
                case MessageType.Default:
                    url = UrlConstants.MessagesUrl;
                    break;
                case MessageType.Inbox:
                    url = UrlConstants.InboxUrl;
                    break;
                case MessageType.Unread:
                    url = UrlConstants.UnreadUrl;
                    break;
                case MessageType.Sent:
                    url = UrlConstants.SentUrl;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return GetListingAsync(url, request, cancellationToken);
        }

        public Task ComposeAsync(ComposeRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync(UrlConstants.ComposeUrl, request, cancellationToken);
        }

        public Task MarkAllMessagesAsReadAsync()
        {
            return PostAsync(UrlConstants.MarkAllMessagesReadUrl, new ReadAllMessagesRequest());
        }

        #endregion

        #region Subreddits
        public async Task<Subreddit> GetSubredditAsync(string subreddit,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetAsync<Subreddit>(string.Format(UrlConstants.SubredditAboutUrl, subreddit),
                cancellationToken: cancellationToken);
        }

        public Task<Listing> GetNewSubredditsAsync(ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetListingAsync(UrlConstants.NewSubredditsUrl, request, cancellationToken);
        }

        #endregion

        #region Links
        public Task<Listing> GetFrontLinksAsync(ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetListingAsync(UrlConstants.FrontUrl, request, cancellationToken);
        }

        public Task<Listing> GetLinksById(ListingRequest request, IEnumerable<string> ids,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetListingAsync(string.Format(UrlConstants.LinksByIdUrl, string.Join(",", ids)), request,
                cancellationToken);
        }
        #endregion

        #region Misc

        public Task<Account> GetUserAsync(string username,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetAsync<Account>(string.Format(UrlConstants.UserUrl, username), cancellationToken: cancellationToken);
        }

        public Task<Listing> GetUserAsync(UserRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string url;
            switch (request.Type)
            {
                case UserRequestType.Overview:
                    url = UrlConstants.UserOverviewUrl;
                    break;
                case UserRequestType.Submitted:
                    url = UrlConstants.UserSubmittedUrl;
                    break;
                case UserRequestType.Comments:
                    url = UrlConstants.UserCommentsUrl;
                    break;
                case UserRequestType.Upvoted:
                    url = UrlConstants.UserUpvotedUrl;
                    break;
                case UserRequestType.Downvoted:
                    url = UrlConstants.UserDownvotedUrl;
                    break;
                case UserRequestType.Hidden:
                    url = UrlConstants.UserHiddenUrl;
                    break;
                case UserRequestType.Saved:
                    url = UrlConstants.UserSavedUrl;
                    break;
                case UserRequestType.Gilded:
                    url = UrlConstants.UserGildedUrl;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return GetListingAsync(string.Format(url, request.Username), request, cancellationToken);
        }

        public Task<Listing> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetListingAsync(UrlConstants.SearchUrl, request, cancellationToken);
        }

        #endregion

        #region Helpers
        public async Task<Listing> GetListingAsync(string url, ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Listing result = await GetAsync<Listing>(url, request, cancellationToken);
            result.Url = url;

            return result;
        }

        public async Task<List<Listing>> GetMultiListingAsync(string url, ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await GetAsync<List<Listing>>(url, request, cancellationToken);

            foreach (Listing listing in result)
            {
                listing.Url = url;
            }

            return result;
        }

        public async Task<T> GetAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var kvp = obj?.ToKeyValuePairs().Select(p => Tuple.Create(p.Key, p.Value));

            HttpResponseMessage resp = await Client.GetAsync(url + WebUtils.ToQueryString(kvp), cancellationToken)
                .ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            string respStr = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            T result = JsonConvert.DeserializeObject<T>(respStr, SerializerSettings);

            return result;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T obj,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(obj.ToKeyValuePairs());

            HttpResponseMessage resp = await Client.PostAsync(url, content, cancellationToken)
                .ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            return resp;
        }

        public async Task<TResult> PostAsync<TResult>(string url, object obj,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResult : Thing
        {
            HttpResponseMessage resp = await PostAsync(url, obj, cancellationToken).ConfigureAwait(false);

            string respStr = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            TResult result = JsonConvert.DeserializeObject<TResult>(respStr, SerializerSettings);

            return result;
        }

        public async Task<HttpResponseMessage> PatchAsync<T>(string url, T obj,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(obj, SerializerSettings),
                Encoding.UTF8, "text/json");

            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            };

            HttpResponseMessage resp = await Client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            return resp;
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T obj,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(obj, SerializerSettings),
                Encoding.UTF8, "text/json");

            HttpResponseMessage resp = await Client.PutAsync(url, content, cancellationToken)
                .ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            return resp;
        }

        public async Task<HttpResponseMessage> UploadAsync<T>(string url, string filename, string contentType, Stream stream, T obj,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            MultipartFormDataContent content = new MultipartFormDataContent("Upload----" +
                DateTime.Now.ToString(CultureInfo.InvariantCulture));

            var kvps = obj.ToKeyValuePairs();
            foreach (var kvp in kvps)
            {
                StringContent sContent = new StringContent(kvp.Value);
                content.Add(sContent, kvp.Key);
            }

            StreamContent fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);

            content.Add(fileContent, "file", filename);

            HttpResponseMessage resp = await Client.PostAsync(url, content, cancellationToken)
                .ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            return resp;
        }
        #endregion
    }
}
