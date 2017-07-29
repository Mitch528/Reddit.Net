using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedditNet.Constants;
using RedditNet.Json;
using RedditNet.Requests;

namespace RedditNet.Things
{
    public class Link : Thing, IVotable, ICreated
    {
        #region Inherited Properties
        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public DateTime CreatedLocal { get; set; }
        public DateTime CreatedUtc { get; set; }
        #endregion

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("author_flair_css_class")]
        public string AuthorFlairCssClass { get; set; }

        [JsonProperty("author_flair_text")]
        public string AuthorFlairText { get; set; }

        [JsonProperty("clicked")]
        public bool Clicked { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("is_self")]
        public bool IsSelf { get; set; }

        [JsonProperty("link_flair_css_class")]
        public string LinkFlairCssClass { get; set; }

        [JsonProperty("link_flair_text")]
        public string LinkFlairText { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("media")]
        public object Media { get; set; }

        [JsonProperty("media_embed")]
        public object MediaEmbed { get; set; }

        [JsonProperty("num_comments")]
        public int NumComments { get; set; }

        [JsonProperty("over_18")]
        public bool Over18 { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("saved")]
        public bool Saved { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("self_text")]
        public string SelfText { get; set; }

        [JsonProperty("self_text_html")]
        public string SelfTextHtml { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonConverter(typeof(EditedConverter))]
        [JsonProperty("edited")]
        public Edited Edited { get; set; }

        [JsonProperty("distinguished")]
        public string Distinguished { get; set; }

        [JsonProperty("stickied")]
        public bool Stickied { get; set; }

        public async Task<Listing> GetCommentsAsync(GetCommentsRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var listings = await Api.GetMultiListingAsync(string.Format(UrlConstants.LinkCommentsUrl, Subreddit, Id), request,
                cancellationToken);

            return listings.Last();
        }

        public Task<Comment> SubmitCommentAsync(string comment,
             CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync<Comment>(UrlConstants.SubmitCommentUrl,
                new CommentRequest { ThingId = FullName, Text = comment }, cancellationToken);
        }

        public Task HideAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.HideLinkUrl, new { id = FullName }, cancellationToken);
        }

        public Task UnhideAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.UnhideLinkUrl, new { id = FullName }, cancellationToken);
        }

        public Task LockAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.LockLinkUrl, new { id = FullName }, cancellationToken);
        }

        public Task UnlockAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.UnlockLinkUrl, new { id = FullName }, cancellationToken);
        }

        public Task MarkNsfwAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.MarkLinkNsfwUrl, new { id = FullName }, cancellationToken);
        }

        public Task UnmarkNsfwAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.UnmarkLinkNsfwUrl, new { id = FullName }, cancellationToken);
        }

        public Task ReportAsync(string reason, string otherReason = "", string siteReason = "",
             CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.ReportUrl, new ReportRequest
            {
                Reason = reason,
                OtherReason = otherReason,
                SiteReason = siteReason,
                ThingId = FullName
            }, cancellationToken);
        }

        public Task SaveAsync(string category = "", CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.SaveUrl, new { id = FullName, category }, cancellationToken);
        }

        public Task SetSendRepliesEnabledAsync(bool enabled, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.SendRepliesUrl, new { id = FullName, state = enabled },
                cancellationToken);
        }

        public Task SetContestModeEnabledAsync(bool enabled, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.SetContestModeUrl, new ContestModeRequest
            {
                Id = FullName,
                State = enabled
            }, cancellationToken);
        }

        public Task SetSubredditStickyAsync(bool stickied, int? num = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.SetSubredditStickyUrl, new SubredditStickyRequest
            {
                Id = FullName,
                Num = num,
                State = stickied
            }, cancellationToken);
        }

        public Task SetSuggestedSortAsync(SuggestedSort sort, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.SetSuggestedSortUrl, new SuggestedSortRequest
            {
                Id = FullName,
                Sort = sort
            }, cancellationToken);
        }

        public Task VoteAsync(VoteDirection vote, int rank, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.VoteUrl, new { id = FullName, dir = (int)vote, rank },
                cancellationToken);
        }

        public Task ApproveAsync()
        {
            return Api.PostAsync(UrlConstants.ApproveUrl, new { id = FullName });
        }
    }
}
