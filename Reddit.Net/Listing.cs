using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Newtonsoft.Json;
using RedditNet.Things;
using System.Reactive.Linq;
using System.Threading.Tasks;
using RedditNet.Extensions;

namespace RedditNet
{
    [JsonObject]
    public class Listing : IEnumerable<Thing>
    {
        [JsonIgnore]
        public RedditApi Api { get; set; }

        [JsonIgnore]
        internal string Url { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("children")]
        public List<Thing> Children { get; set; } = new List<Thing>();

        public int Count => Children.Count;

        public IEnumerator<Thing> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IObservable<Thing> GetStream(int limit = 25, TimeSpan? delay = null)
        {
            delay = delay ?? TimeSpan.FromSeconds(15);

            return Observable.Create<Thing>(async (observer, cts) =>
            {
                Listing listing = this;

                if (!listing.Any())
                {
                    observer.OnCompleted();

                    return;
                }

                string before = listing.FirstOrDefault()?.FullName;

                listing.Before = before;

                while (true)
                {
                    if (cts.IsCancellationRequested)
                        break;

                    if (!string.IsNullOrEmpty(listing.Before))
                    {
                        listing = await listing.GetPreviousListingAsync(limit, cts);

                        if (listing.Any())
                        {
                            before = listing.First().FullName;
                        }

                        foreach (Thing thing in listing)
                        {
                            observer.OnNext(thing);
                        }

                        listing.Before = before;
                    }

                    await Task.Delay(delay.Value, cts);
                }

                observer.OnCompleted();
            });
        }
    }
}
