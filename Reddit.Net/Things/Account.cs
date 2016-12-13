using System;
using Newtonsoft.Json;

namespace RedditNet.Things
{
    public class Account : Thing, ICreated
    {
        #region Inherited Properties
        public DateTime CreatedLocal { get; set; }
        public DateTime CreatedUtc { get; set; }
        #endregion

        [JsonProperty("comment_karma")]
        public int CommentKarma { get; set; }

        [JsonProperty("has_mail")]
        public bool HasMail { get; set; }

        [JsonProperty("has_mod_mail")]
        public bool HasModMail { get; set; }

        [JsonProperty("has_verified_email")]
        public bool HasVerifiedEmail { get; set; }

        [JsonProperty("inbox_count")]
        public int InboxCount { get; set; }

        [JsonProperty("is_friend")]
        public bool IsFriend { get; set; }

        [JsonProperty("is_gold")]
        public bool IsGold { get; set; }

        [JsonProperty("is_mod")]
        public bool IsMod { get; set; }

        [JsonProperty("link_karma")]
        public int LinkKarma { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("over_18")]
        public bool Over18 { get; set; }
    }
}
