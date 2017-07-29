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
                var listing = this.Clone();

                while (true)
                {
                    if (cts.IsCancellationRequested)
                        break;

                    listing = await listing.GetPreviousListingAsync(limit, cts);

                    foreach (Thing thing in listing)
                    {
                        observer.OnNext(thing);
                    }

                    await Task.Delay(delay.Value, cts);
                }

                observer.OnCompleted();
            });
        }

        public Listing Clone()
        {
            var clone = new Listing
            {
                Api = Api,
                Url = Url,
                Before = Before,
                After = After,
                Children = Children.ToList()
            };

            return clone;
        }
    }
}
