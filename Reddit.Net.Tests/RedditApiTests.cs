using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using RedditNet.Extensions;
using RedditNet.Requests;
using RedditNet.Things;
using Xunit;
using Xunit.Abstractions;

namespace RedditNet.Tests
{
    public class RedditApiTests
    {
        private readonly ITestOutputHelper _output;

        public RedditApiTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

        [Fact]
        public async Task TestListingStream()
        {
            RedditApi api = new RedditApi();
            Subreddit subreddit = await api.GetSubredditAsync(TestSubredditName);

            Listing listing = await subreddit.GetCommentsAsync(new GetCommentsRequest
            {
                Sort = CommentSort.New,
                Limit = 25
            });

            var stream = listing.GetStream()
                .Take(50);

            IDisposable subscription = stream.Subscribe(thing =>
            {
                Comment comment = thing as Comment;

                if (comment != null)
                {
                    _output.WriteLine("Comment by: " + comment.Author);
                }
            });

            var things = await stream.ToList().ToTask();

            subscription.Dispose();

            Assert.Equal(50, things.Count);
        }
    }
}
