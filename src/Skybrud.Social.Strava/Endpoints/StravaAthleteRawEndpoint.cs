using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Strava.OAuth;
using Skybrud.Social.Strava.Options.Athletes;

namespace Skybrud.Social.Strava.Endpoints;

/// <summary>
/// Raw implementation of the <strong>Athlete</strong> endpoint.
/// </summary>
public class StravaAthleteRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the underlying <see cref="StravaOAuthClient"/>.
    /// </summary>
    public StravaOAuthClient Client { get; }

    #endregion

    #region Constructors

    internal StravaAthleteRawEndpoint(StravaOAuthClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public IHttpResponse GetAthlete() {
        return GetAthlete(new StravaGetAthleteOptions());
    }

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <param name="options">The options for the request to the Strava API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public IHttpResponse GetAthlete(StravaGetAthleteOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public async Task<IHttpResponse> GetAthleteAsync() {
        return await GetAthleteAsync(new StravaGetAthleteOptions());
    }

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <param name="options">The options for the request to the Strava API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public async Task<IHttpResponse> GetAthleteAsync(StravaGetAthleteOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    public IHttpResponse GetActivities() {
        return GetActivities(new StravaGetAthleteActiviesOptions());
    }

    public IHttpResponse GetActivities(StravaGetAthleteActiviesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

}