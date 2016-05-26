using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Reddit.Net.Requests;
using Reddit.Net.Things;

namespace Reddit.Net.Extensions
{
    public static class ListingExtensions
    {
        public static Task<Listing> GetPreviousListingAsync(this Listing listing, int limit,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new ListingRequest
            {
                Before = listing.Before,
                Limit = limit
            };

            return listing.Api.GetListingAsync(listing.Url, request, cancellationToken);
        }

        public static Task<Listing> GetNextListingAsync(this Listing listing, int limit,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new ListingRequest
            {
                After = listing.After,
                Limit = limit
            };

            return listing.Api.GetListingAsync(listing.Url, request, cancellationToken);
        }
    }
}
