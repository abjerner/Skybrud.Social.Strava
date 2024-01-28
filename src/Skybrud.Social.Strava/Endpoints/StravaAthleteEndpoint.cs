using System.Threading.Tasks;
using Skybrud.Social.Strava.Options.Athletes;
using Skybrud.Social.Strava.Responses.Activities;
using Skybrud.Social.Strava.Responses.Athletes;

namespace Skybrud.Social.Strava.Endpoints;

/// <summary>
/// Implementation of the <strong>Athlete</strong> endpoint.
/// </summary>
public class StravaAthleteEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the Strava service implementation.
    /// </summary>
    public StravaHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public StravaAthleteRawEndpoint Raw => Service.Client.Athlete;

    #endregion

    #region Constructors

    internal StravaAthleteEndpoint(StravaHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <returns>An instance of <see cref="StravaAthleteResponse"/> representing the response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public StravaAthleteResponse GetAthlete() {
        return new StravaAthleteResponse(Raw.GetAthlete());
    }

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <param name="options">The options for the request to the Strava API.</param>
    /// <returns>An instance of <see cref="StravaAthleteResponse"/> representing the response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public StravaAthleteResponse GetAthlete(StravaGetAthleteOptions options) {
        return new StravaAthleteResponse(Raw.GetAthlete(options));
    }

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <returns>An instance of <see cref="StravaAthleteResponse"/> representing the response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public async Task<StravaAthleteResponse> GetAthleteAsync() {
        return new StravaAthleteResponse(await Raw.GetAthleteAsync());
    }

    /// <summary>
    /// Returns information about the authenticated athlete.
    /// </summary>
    /// <param name="options">The options for the request to the Strava API.</param>
    /// <returns>An instance of <see cref="StravaAthleteResponse"/> representing the response from the Strava API.</returns>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/reference/#api-Athletes-getLoggedInAthlete</cref>
    /// </see>
    public async Task<StravaAthleteResponse> GetAthleteAsync(StravaGetAthleteOptions options) {
        return new StravaAthleteResponse(await Raw.GetAthleteAsync(options));
    }

    public StravaActivityListResponse GetActivities() {
        return new StravaActivityListResponse(Raw.GetActivities());
    }

    public StravaActivityListResponse GetActivities(StravaGetAthleteActiviesOptions options) {
        return new StravaActivityListResponse(Raw.GetActivities(options));
    }

    public async Task<StravaActivityListResponse> GetActivitiesAsync() {
        return new StravaActivityListResponse(await Raw.GetActivitiesAsync());
    }

    public async Task<StravaActivityListResponse> GetActivitiesAsync(StravaGetAthleteActiviesOptions options) {
        return new StravaActivityListResponse(await Raw.GetActivitiesAsync(options));
    }

    #endregion

}