using System;
using System.Collections.Generic;
using System.Linq;
using RedditNet.Requests;
using RedditNet.Things;

namespace RedditNet.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new RedditApi();
            var subreddit = api.GetSubredditAsync("noveltranslations").Result;
            var links = subreddit.GetHotLinksAsync(new ListingRequest { Limit = 2 }).Result;

            foreach (Link link in links.OfType<Link>())
            {
                Console.WriteLine($"Link - {link.Title}");

                var comments = link.GetCommentsAsync(new GetCommentsRequest { Limit = 5 }).Result;
                foreach (Comment comment in comments.OfType<Comment>())
                {
                    Console.WriteLine($"- Comment - \"{comment.Body}\" by {comment.Author}");
                }
                
                More more = comments.LastOrDefault() as More;

                var someMoreComments = more?.Children.Take(2) ?? new List<string>();
                foreach (string anotherComment in someMoreComments)
                {
                    Comment aComment = subreddit.GetCommentAsync(new GetCommentRequest { LinkId = link.Id, CommentId = anotherComment })
                        .Result;

                    Console.WriteLine($"-- Another comment {aComment.Body}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
