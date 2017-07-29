namespace RedditNet.Constants
{
    public static class UrlConstants
    {
        public const string RedditBaseUrl = "https://www.reddit.com";

        public const string RedditBaseOAuthApiUrl = "https://oauth.reddit.com";

        public const string MeUrl = "/api/v1/me";

        public const string MePrefsUrl = "/api/v1/me/prefs";

        public const string FrontUrl = "/.json";

        public const string SubredditAboutUrl = "/r/{0}/about.json";

        public const string SubredditHotLinksUrl = "/r/{0}/hot.json";

        public const string SubredditNewLinksUrl = "/r/{0}/new.json";

        public const string SubredditRisingLinksUrl = "/r/{0}/rising.json";

        public const string SubredditRandomLinksUrl = "/r/{0}/random.json";

        public const string NewSubredditsUrl = "/subreddits/new.json";

        public const string SubredditSubscribeUrl = "/api/subscribe";

        public const string SubmitCommentUrl = "/api/comment";

        public const string DeleteLinkOrCommentUrl = "/api/del";

        public const string EditUserTextUrl = "/api/editusertext";

        public const string HideLinkUrl = "/api/hide";

        public const string UnhideLinkUrl = "/api/unhide";

        public const string LockLinkUrl = "/api/lock";

        public const string UnlockLinkUrl = "/api/unlock";

        public const string MarkLinkNsfwUrl = "/api/marknsfw";

        public const string UnmarkLinkNsfwUrl = "/api/unmarknsfw";

        public const string ReportUrl = "/api/report";

        public const string SaveUrl = "/api/save";

        public const string SendRepliesUrl = "/api/sendreplies";

        public const string SetContestModeUrl = "/api/set_contest_mode";

        public const string SetSubredditStickyUrl = "/api/set_subreddit_sticky";

        public const string SetSuggestedSortUrl = "/api/set_suggested_sort";

        public const string SubmitLinkUrl = "/api/submit";

        public const string VoteUrl = "/api/vote";

        public const string LinksByIdUrl = "/by_id/{0}";

        public const string LinkCommentsUrl = "/r/{0}/comments/{1}.json";

        public const string CommentsUrl = "/r/{0}/comments.json";

        public const string ApproveUrl = "/api/approve";

        public const string SearchSubredditUrl = "/r/{0}/search.json";

        public const string SearchUrl = "/search.json";

        public const string ComposeUrl = "/api/compose";

        public const string MarkAllMessagesReadUrl = "/api/read_all_messages";

        public const string MarkMessageRead = "/api/read_message";

        public const string UnmarkMessageRead = "/api/unread_message";

        public const string MessagesUrl = "/message/messages.json";

        public const string InboxUrl = "/message/inbox.json";

        public const string UnreadUrl = "/message/unread.json";

        public const string SentUrl = "/message/sent.json";

        public const string UserUrl = "/user/{0}/about.json";

        public const string UserOverviewUrl = "/user/{0}/overview.json";

        public const string UserSubmittedUrl = "/user/{0}/submitted.json";

        public const string UserCommentsUrl = "/user/{0}/comments.json";

        public const string UserUpvotedUrl = "/user/{0}/upvoted.json";

        public const string UserDownvotedUrl = "/user/{0}/downvoted.json";

        public const string UserHiddenUrl = "/user/{0}/hidden.json";

        public const string UserSavedUrl = "/user/{0}/saved.json";

        public const string UserGildedUrl = "/user/{0}/gilded.json";

        public const string SetUserFlairUrl = "/api/flair";
    }
}
