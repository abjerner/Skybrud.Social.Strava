using Skybrud.Essentials.Http;
using Skybrud.Social.Strava.Models.Authentication;

namespace Skybrud.Social.Strava.Responses.Authentication {

    /// <summary>
    /// Class representing a response with information about an access token.
    /// </summary>
    public class StravaTokenResponse : StravaResponse<StravaToken> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public StravaTokenResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, StravaToken.Parse);
        }

    }

}