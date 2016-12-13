using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedditNet
{
    public class UserPreferences
    {
        [JsonProperty("default_theme_sr")]
        public string DefaultThemeSr { get; set; }

        [JsonProperty("threaded_messages")]
        public bool? ThreadedMessages { get; set; }

        [JsonProperty("hide_downs")]
        public bool? HideDowns { get; set; }

        [JsonProperty("show_stylesheets")]
        public bool? ShowStylesheets { get; set; }

        [JsonProperty("show_link_flair")]
        public bool? ShowLinkFlair { get; set; }

        [JsonProperty("creddit_autorenew")]
        public bool? CreditAutoRenew { get; set; }

        [JsonProperty("show_trending")]
        public bool? ShowTrending { get; set; }

        [JsonProperty("private_feeds")]
        public bool? PrivateFeeds { get; set; }

        [JsonProperty("monitor_mentions")]
        public bool? MonitorMentions { get; set; }

        [JsonProperty("show_snoovatar")]
        public bool? ShowSnoovatar { get; set; }

        [JsonProperty("research")]
        public bool? Research { get; set; }

        [JsonProperty("ignore_suggested_sort")]
        public bool? IgnoreSuggestedSort { get; set; }

        [JsonProperty("media")]
        public string Media { get; set; }

        [JsonProperty("clickgadget")]
        public bool? ClickGadget { get; set; }

        [JsonProperty("use_global_defaults")]
        public bool? UseGlobalDefaults { get; set; }

        [JsonProperty("label_nsfw")]
        public bool? LabelNsfw { get; set; }

        [JsonProperty("over_18")]
        public bool? Over18 { get; set; }

        [JsonProperty("email_messages")]
        public bool? EmailMessages { get; set; }

        [JsonProperty("highlight_controversial")]
        public bool? HighlightControversial { get; set; }

        [JsonProperty("force_https")]
        public bool? ForceHttps { get; set; }

        [JsonProperty("domain_details")]
        public bool? DomainDetails { get; set; }

        [JsonProperty("collapse_left_bar")]
        public bool? CollapseLeftBar { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("hide_ups")]
        public bool? HideUps { get; set; }

        [JsonProperty("public_server_seconds")]
        public bool? PublicServerSeconds { get; set; }

        [JsonProperty("hide_from_robots")]
        public bool? HideFromRobots { get; set; }

        [JsonProperty("compress")]
        public bool? Compress { get; set; }

        [JsonProperty("store_visits")]
        public bool? StoreVisits { get; set; }

        [JsonProperty("threaded_modmail")]
        public bool? ThreadedModMail { get; set; }

        [JsonProperty("min_link_score")]
        public int? MinLinkScore { get; set; }

        [JsonProperty("media_preview")]
        public string MediaPreview { get; set; }

        [JsonProperty("enable_default_themes")]
        public bool? EnableDefaultThemes { get; set; }

        [JsonProperty("content_langs")]
        public List<string> ContentLangs { get; set; }

        [JsonProperty("show_promote")]
        public bool? ShowPromote { get; set; }

        [JsonProperty("min_comment_score")]
        public int? MinCommentScore { get; set; }

        [JsonProperty("public_votes")]
        public bool? PublicVotes { get; set; }

        [JsonProperty("organic")]
        public bool? Organic { get; set; }

        [JsonProperty("collapse_read_messages")]
        public bool? CollapseReadMessages { get; set; }

        [JsonProperty("show_flair")]
        public bool? ShowFlair { get; set; }

        [JsonProperty("mark_messages_read")]
        public bool? MarkMessagesRead { get; set; }

        [JsonProperty("no_profanity")]
        public bool? NoProfanity { get; set; }

        [JsonProperty("hide_ads")]
        public bool? HideAds { get; set; }

        [JsonProperty("beta")]
        public bool? Beta { get; set; }

        [JsonProperty("newwindow")]
        public bool? NewWindow { get; set; }

        [JsonProperty("numsites")]
        public int? NumSites { get; set; }

        [JsonProperty("legacy_search")]
        public bool? LegacySearch { get; set; }

        [JsonProperty("num_comments")]
        public int? NumComments { get; set; }

        [JsonProperty("show_gold_expiration")]
        public bool? ShowGoldExpiration { get; set; }

        [JsonProperty("highlight_new_comments")]
        public bool? HighlightNewComments { get; set; }

        [JsonProperty("default_comment_sort")]
        public string DefaultCommentSort { get; set; }

        [JsonProperty("hide_locationbar")]
        public bool? HideLocationBar { get; set; }
    }
}
