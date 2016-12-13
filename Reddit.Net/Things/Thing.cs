namespace RedditNet.Things
{
    public class Thing : IThing
    {
        #region Inherited Properties
        public RedditApi Api { get; set; }

        public string Id { get; set; }

        public string FullName { get; set; }

        #endregion
    }
}

