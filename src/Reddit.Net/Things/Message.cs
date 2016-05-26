using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Constants;
using Reddit.Net.Requests;

namespace Reddit.Net.Things
{
    public class Message : Thing, ICreated
    {
        #region Inherited Properties
        public DateTime CreatedLocal { get; set; }
        public DateTime CreatedUtc { get; set; }
        #endregion

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("first_message")]
        public int? FirstMessage { get; set; }

        [JsonProperty("first_message_name")]
        public string FirstMessageName { get; set; }

        [JsonProperty("likes")]
        public bool? Likes { get; set; }

        [JsonProperty("link_title")]
        public string LinkTitle { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("replies")]
        public List<Message> Replies { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("was_comment")]
        public bool WasComment { get; set; }

        public Task ReplyAsync(string reply, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.SubmitCommentUrl, new CommentRequest
            {
                Text = reply,
                ThingId = FullName
            }, cancellationToken);
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

        public Task MarkMessageAsReadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.MarkMessageRead, new ReadMessageRequest { Id = FullName },
                cancellationToken);
        }

        public Task UnmarkMessageAsReadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.PostAsync(UrlConstants.UnmarkMessageRead, new UnreadMessageRequest { Id = FullName },
                cancellationToken);
        }
    }
}
