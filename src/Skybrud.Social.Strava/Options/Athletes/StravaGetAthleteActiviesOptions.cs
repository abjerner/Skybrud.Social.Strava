using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Strava.Options.Athletes;

public class StravaGetAthleteActiviesOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// A timestamp to use for filtering activities that have taken place before a certain time.
    /// </summary>
    public EssentialsTime Before { get; set; }

    /// <summary>
    /// A timestamp to use for filtering activities that have taken place after a certain time.
    /// </summary>
    public EssentialsTime After { get; set; }

    /// <summary>
    /// Page number. Defaults to 1 if not specified.
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Number of items per page. Defaults to 30 if not specified.
    /// </summary>
    public int? PerPage { get; set; }

    #endregion

    #region Member methods

    public IHttpRequest GetRequest() {

        IHttpQueryString query = new HttpQueryString();

        if (Page != null) query.Add("page", Page);
        if (PerPage != null) query.Add("per_page", PerPage);

        return HttpRequest.Get("/api/v3/athlete/activities", query);

    }

    #endregion

}