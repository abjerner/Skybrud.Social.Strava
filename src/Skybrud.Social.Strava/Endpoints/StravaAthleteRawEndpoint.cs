using System;
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

    public IHttpResponse GetActivities() {
        return GetActivities(new StravaGetAthleteActiviesOptions());
    }

    public IHttpResponse GetActivities(StravaGetAthleteActiviesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

}