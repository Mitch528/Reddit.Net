using System;
using System.Runtime.Serialization;

namespace RedditNet.Auth
{
    [Flags]
    public enum RedditScope
    {
        [EnumMember(Value = "")]
        None = 1 << 0,
        [EnumMember(Value = "account")]
        Account = 1 << 1,
        [EnumMember(Value = "identity")]
        Identity = 1 << 2,
        [EnumMember(Value = "edit")]
        Edit = 1 << 3,
        [EnumMember(Value = "flair")]
        Flair = 1 << 4,
        [EnumMember(Value = "history")]
        History = 1 << 5,
        [EnumMember(Value = "modconfig")]
        ModConfig = 1 << 6,
        [EnumMember(Value = "modflair")]
        ModFlair = 1 << 7,
        [EnumMember(Value = "modlog")]
        ModLog = 1 << 8,
        [EnumMember(Value = "modposts")]
        ModPosts = 1 << 9,
        [EnumMember(Value = "modwiki")]
        ModWiki = 1 << 10,
        [EnumMember(Value = "mysubreddits")]
        MySubreddits = 1 << 11,
        [EnumMember(Value = "privatemessages")]
        PrivateMessages = 1 << 12,
        [EnumMember(Value = "read")]
        Read = 1 << 13,
        [EnumMember(Value = "report")]
        Report = 1 << 14,
        [EnumMember(Value = "save")]
        Save = 1 << 15,
        [EnumMember(Value = "submit")]
        Submit = 1 << 16,
        [EnumMember(Value = "subscribe")]
        Subscribe = 1 << 17,
        [EnumMember(Value = "vote")]
        Vote = 1 << 18,
        [EnumMember(Value = "wikiedit")]
        WikiEdit = 1 << 19,
        [EnumMember(Value = "wikiread")]
        WikiRead = 1 << 20,
        All = Account | Identity | Edit | Flair | History | ModConfig | ModFlair | ModLog | ModPosts
            | ModWiki | MySubreddits | PrivateMessages | Read | Report | Save | Submit | Subscribe | Vote | WikiEdit | WikiRead
    }
}
