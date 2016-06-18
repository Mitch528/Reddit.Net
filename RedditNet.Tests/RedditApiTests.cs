using System.Linq;
using System.Threading.Tasks;
using RedditNet.Extensions;
using RedditNet.Requests;
using RedditNet.Things;
using Xunit;

namespace RedditNet.Tests
{
    public class RedditApiTests
    {
        const string TestSubredditName = "noveltranslations";

        [Fact]
        public async Task TestGetSubreddit()
        {
            RedditApi api = new RedditApi();
            Subreddit subreddit = await api.GetSubredditAsync(TestSubredditName);

            Assert.Equal(TestSubredditName, subreddit.Name);
        }

        [Fact]
        public async Task TestGetSubredditLinks()
        {
            RedditApi api = new RedditApi();
            Subreddit subreddit = await api.GetSubredditAsync(TestSubredditName);
            Listing listing = await subreddit.GetNewLinksAsync(new ListingRequest { Limit = 5 });

            var result = listing.ToList();

            foreach (Thing thing in result)
            {
                Assert.IsAssignableFrom(typeof(Link), thing);
            }
        }

        [Fact]
        public async Task TestGetNextListing()
        {
            RedditApi api = new RedditApi();
            Subreddit subreddit = await api.GetSubredditAsync(TestSubredditName);
            Listing listing = await subreddit.GetNewLinksAsync(new ListingRequest { Limit = 1 });

            Listing next = await listing.GetNextListingAsync(1);
            Assert.Equal(1, next.Count);
        }

        [Fact]
        public async Task TestSubredditSearch()
        {
            RedditApi api = new RedditApi();
            Subreddit subreddit = await api.GetSubredditAsync(TestSubredditName);
            Listing listing = await subreddit.SearchAsync(new SearchRequest
            {
                Sort = SearchSort.Hot,
                Limit = 10
            });

            Assert.Equal(10, listing.Count);
        }
    }
}
