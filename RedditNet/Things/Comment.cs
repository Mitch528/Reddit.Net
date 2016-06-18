using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedditNet.Constants;
using RedditNet.Json;
using RedditNet.Requests;

namespace RedditNet.Things
{
    public class Comment : Thing, IVotable, ICreated
    {
        #region Inherited Properties
        public int Ups { get; set; }
        public int Downs { get; set; }
        public bool? Likes { get; set; }
        public DateTime CreatedLocal { get; set; }
        public DateTime CreatedUtc { get; set; }
        #endregion

        [JsonProperty("approved_by")]
        public string ApprovedBy { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("author_flair_css_class")]
        public string AuthorFlairCssClass { get; set; }

        [JsonProperty("author_flair_text")]
        public string AuthorFlairText { get; set; }

        [JsonProperty("banned_by")]
        public string BannedBy { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonConverter(typeof(EditedConverter))]
        [JsonProperty("edited")]
        public Edited Edited { get; set; }

        [JsonProperty("gilded")]
        public int Gilded { get; set; }

        [JsonProperty("link_author")]
        public string LinkAuthor { get; set; }

        [JsonProperty("link_id")]
        public string LinkId { get; set; }

        [JsonProperty("link_title")]
        public string LinkTitle { get; set; }

        [JsonProperty("link_url")]
        public string LinkUrl { get; set; }

        [JsonProperty("num_reports")]
        public int? NumReports { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("replies")]
        public Listing Replies { get; set; }

        [JsonProperty("saved")]
        public bool Saved { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("score_hidden")]
        public bool ScoreHidden { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonProperty("distinguished")]
        public string Distinguished { get; set; }

        public Task EditUserTextAsync(string newText, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.EditUserTextUrl, new EditUserTextRequest { ThingId = FullName, Text = newText },
                cancellationToken);
        }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.DeleteLinkOrCommentUrl, new { id = FullName },
                cancellationToken);
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

        public Task ApproveAsync()
        {
            return Api.PostAsync(UrlConstants.ApproveUrl, new { id = FullName });
        }
    }
}
