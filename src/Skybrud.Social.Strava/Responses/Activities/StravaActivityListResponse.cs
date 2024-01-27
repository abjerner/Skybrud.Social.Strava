using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Strava.Models.Activities;

namespace Skybrud.Social.Strava.Responses.Activities {

    /// <summary>
    /// Class representing a response with a list of <see cref="StravaActivitySummary"/>.
    /// </summary>
    public class StravaActivityListResponse : StravaResponse<IReadOnlyList<StravaActivitySummary>> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public StravaActivityListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, StravaActivitySummary.Parse);
        }

    }

}