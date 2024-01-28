using System;
using System.Threading.Tasks;
using Skybrud.Social.Strava.Endpoints;
using Skybrud.Social.Strava.OAuth;
using Skybrud.Social.Strava.Responses.Authentication;

namespace Skybrud.Social.Strava;

/// <summary>
/// Class working as an entry point to making requests to the various endpoints of the Strava API.
/// </summary>
public class StravaHttpService {

    #region Properties

    /// <summary>
    /// Gets a reference to the underlying HTTP client.
    /// </summary>
    public StravaOAuthClient Client { get; set; }

    /// <summary>
    /// Gets a reference to the <strong>Athletes</strong> endpoint.
    /// </summary>
    public StravaAthleteEndpoint Athlete { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options
    /// </summary>
    public StravaHttpService(StravaOAuthClient client) {
        Client = client;
        Athlete = new StravaAthleteEndpoint(this);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Returns a new instance of <see cref="StravaHttpService"/> based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
    /// <returns>A new instance of <see cref="StravaHttpService"/>.</returns>
    public static StravaHttpService CreateFromClient(StravaOAuthClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return new StravaHttpService(client);
    }

    public static StravaHttpService CreateFromAccessToken(string accessToken) {
        if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
        return new StravaHttpService(new StravaOAuthClient { AccessToken = accessToken });
    }

    public static StravaHttpService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {

        // Validate the input
        if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
        if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
        if (string.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

        // Initialize a new OAuth client
        StravaOAuthClient client = new(clientId, clientSecret);

        // Get a new access token from the request token
        StravaTokenResponse response = client.GetAccessTokenFromRefereshToken(refreshToken);

        // Update the client with the access token from the response body
        client.AccessToken = response.Body.AccessToken;

        // Initialize and return a new HTTP service instance
        return new StravaHttpService(client);

    }

    public static async Task<StravaHttpService> CreateFromRefreshTokenAsync(string clientId, string clientSecret, string refreshToken) {

        // Validate the input
        if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
        if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
        if (string.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

        // Initialize a new OAuth client
        StravaOAuthClient client = new(clientId, clientSecret);

        // Get a new access token from the request token
        StravaTokenResponse response = await client.GetAccessTokenFromRefereshTokenAsync(refreshToken);

        // Update the client with the access token from the response body
        client.AccessToken = response.Body.AccessToken;

        // Initialize and return a new HTTP service instance
        return new StravaHttpService(client);

    }

    #endregion

}