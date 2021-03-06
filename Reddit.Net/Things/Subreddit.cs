﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RedditNet.Constants;
using RedditNet.Requests;

namespace RedditNet.Things
{
    public class Subreddit : Thing
    {
        private static readonly Regex NameRegex = new Regex(@"\/?r\/(?<name>.*)\/?", RegexOptions.Compiled);

        private string _name;

        [JsonProperty("accounts_active")]
        public int? AccountsActive { get; set; }

        [JsonProperty("comment_score_hide_mins")]
        public int CommentScoreHideMins { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_html")]
        public string DescriptionHtml { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("header_img")]
        public string HeaderImage { get; set; }

        [JsonProperty("header_size")]
        public int[] HeaderSize { get; set; }

        [JsonProperty("header_title")]
        public string HeaderTitle { get; set; }

        [JsonProperty("over18")]
        public bool Over18 { get; set; }

        [JsonProperty("public_description")]
        public string PublicDescription { get; set; }

        [JsonProperty("public_traffic")]
        public bool PublicTraffic { get; set; }

        [JsonProperty("subscribers")]
        public long Subscribers { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("submission_type")]
        public SubmissionType SubmissionType { get; set; }

        [JsonProperty("submit_link_label")]
        public string SubmitLinkLabel { get; set; }

        [JsonProperty("submit_text_label")]
        public string SubmitTextLabel { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("subreddit_type")]
        public SubredditType SubredditType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user_is_banned")]
        public bool? UserIsBanned { get; set; }

        [JsonProperty("user_is_contributor")]
        public bool? UserIsContributor { get; set; }

        [JsonProperty("user_is_moderator")]
        public bool? UserIsModerator { get; set; }

        [JsonProperty("user_is_subscriber")]
        public bool? UserIsSubscriber { get; set; }

        public string Name
        {
            get
            {
                if (_name != null)
                    return _name;

                _name = NameRegex.Match(Url).Groups["name"].Value.TrimEnd('/');

                return _name;
            }
        }

        public async Task<Comment> GetCommentAsync(GetCommentRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(request.CommentId))
                throw new ArgumentNullException(nameof(request.CommentId));
            if (string.IsNullOrEmpty(request.LinkId))
                throw new ArgumentNullException(nameof(request.LinkId));

            var listings = await Api.GetMultiListingAsync(string.Format(UrlConstants.LinkCommentsUrl, Name, request.LinkId), request,
                cancellationToken);

            return listings.Last().OfType<Comment>().FirstOrDefault();
        }

        public Task<Listing> GetCommentsAsync(GetCommentsRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.GetListingAsync(string.Format(UrlConstants.CommentsUrl, Name), request,
                cancellationToken);
        }

        public async Task<Listing> GetCommentAndRepliesAsync(GetCommentRepliesRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var listing = await Api.GetMultiListingAsync(string.Format(UrlConstants.CommentRepliesUrl, Name, request.LinkId.Split('_')[1], request.CommentId), request, cancellationToken);

            return listing.LastOrDefault();
        }

        public Task<Listing> GetHotLinksAsync(ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.GetListingAsync(string.Format(UrlConstants.SubredditHotLinksUrl, Name), request,
                cancellationToken);
        }

        public Task<Listing> GetNewLinksAsync(ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.GetListingAsync(string.Format(UrlConstants.SubredditNewLinksUrl, Name), request,
                cancellationToken);
        }

        public Task<Listing> GetRisingLinksAsync(ListingRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.GetListingAsync(string.Format(UrlConstants.SubredditRisingLinksUrl, Name), request,
                cancellationToken);
        }

        public async Task<Link> GetRandomLinkAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new ListingRequest();
            var listings = await Api.GetMultiListingAsync(string.Format(UrlConstants.SubredditRandomLinksUrl, Name), request,
                cancellationToken);

            return listings.FirstOrDefault()?.OfType<Link>().FirstOrDefault();
        }

        public Task SubmitLinkAsync(LinkSubmitRequest submission,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            submission.Subreddit = Name;

            return Api.PostAsync(UrlConstants.SubmitLinkUrl, submission, cancellationToken);
        }

        public Task<Listing> SearchAsync(SearchRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            request.RestrictSr = true;

            return Api.GetListingAsync(string.Format(UrlConstants.SearchSubredditUrl, Name), request, cancellationToken);
        }

        public Task<Listing> GetInfoAsync(InfoRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Api.GetListingAsync(string.Format(UrlConstants.SubredditInfoUrl, Name), request, cancellationToken);
        }

        public Task SubscribeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var obj = new { action = "sub", sr = FullName };

            return Api.PostAsync(UrlConstants.SubredditSubscribeUrl, obj, cancellationToken);
        }

        public Task UnsubscribeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var obj = new { action = "unsub", sr = FullName };

            return Api.PostAsync(UrlConstants.SubredditSubscribeUrl, obj, cancellationToken);
        }

        public Task SetUserFlairAsync(UserFlairRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            request.Subreddit = Name;

            return Api.PostAsync(UrlConstants.SetUserFlairUrl, request, cancellationToken);
        }
    }
}
