using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Skybrud.Social.Strava.Exceptions;

/// <summary>
/// Class representing an exception/error returned by the Strava API.
/// </summary>
public class StravaHttpException : StravaException, IHttpException {

    #region Properties

    /// <summary>
    /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
    /// </summary>
    public IHttpResponse Response { get; }

    /// <summary>
    /// Gets the status code of the underlying response.
    /// </summary>
    public HttpStatusCode StatusCode => Response.StatusCode;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public StravaHttpException(IHttpResponse response) : base("Invalid response received from the Strava API (Status: " + (int) response.StatusCode + ")") {
        Response = response;
    }

    #endregion

}