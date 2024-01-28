using Skybrud.Social.Strava.Options.Athletes;
using Skybrud.Social.Strava.Responses.Activities;

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

    public StravaActivityListResponse GetActivities() {
        return new StravaActivityListResponse(Raw.GetActivities());
    }

    public StravaActivityListResponse GetActivities(StravaGetAthleteActiviesOptions options) {
        return new StravaActivityListResponse(Raw.GetActivities(options));
    }

    #endregion

}