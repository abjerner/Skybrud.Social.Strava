using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Strava.Exceptions;

namespace Skybrud.Social.Strava.Responses {

    /// <summary>
    /// Class representing a response from the Strava API.
    /// </summary>
    public class StravaResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected StravaResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;
            
            throw new StravaHttpException(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Strava API.
    /// </summary>
    public class StravaResponse<T> : StravaResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected StravaResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}