using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;

namespace Skybrud.Social.Strava.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Strava API.
    /// </summary>
    public class StravaHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        public StravaHttpException(SocialHttpResponse response) : base("Invalid response received from the Strava API (Status: " + (int) response.StatusCode + ")") {
            Response = response;
        }

        #endregion

    }

}