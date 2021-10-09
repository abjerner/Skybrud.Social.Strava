using Skybrud.Essentials.Http;
using Skybrud.Social.Strava.Models.Authentication;

namespace Skybrud.Social.Strava.Responses.Authentication {

    /// <summary>
    /// Class representing a response with information about an access token.
    /// </summary>
    public class StravaTokenResponse : StravaResponse<StravaToken> {

        #region Properties


        #endregion

        #region Constructors

        private StravaTokenResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, StravaToken.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="StravaTokenResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="StravaTokenResponse"/> representing the response.</returns>
        public static StravaTokenResponse ParseResponse(IHttpResponse response) {
            return response == null ? null : new StravaTokenResponse(response);
        }

        #endregion

    }

}