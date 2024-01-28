using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Strava.Options.Athletes;

/// <summary>
/// Class describing the request options for getting information about the authenticated athlete.
/// </summary>
public class StravaGetAthleteOptions : IHttpRequestOptions {

    #region Member methods

    public IHttpRequest GetRequest() {
        return HttpRequest.Get("/api/v3/athlete");
    }

    #endregion

}