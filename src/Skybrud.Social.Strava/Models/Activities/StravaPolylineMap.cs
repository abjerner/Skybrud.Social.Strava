using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Strava.Models.Activities;

/// <see>
///     <cref>https://developers.strava.com/docs/reference/#api-models-PolylineMap</cref>
/// </see>
public class StravaPolylineMap {

    #region Properties

    /// <summary>
    /// Gets the identifier of the map.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the polyline of the map.
    /// </summary>
    public string Polyline { get; }

    /// <summary>
    /// Gets the summary polyline of the map.
    /// </summary>
    public string PolylineSummary { get; }

    #endregion

    #region Constructors

    private StravaPolylineMap(JObject json) {
        Id = json.GetString("id");
        Polyline = json.GetString("polyline");
        PolylineSummary = json.GetString("summary_polyline");
    }

    #endregion

    #region Static methods

    public static StravaPolylineMap Parse(JObject json) {
        return json == null ? null : new StravaPolylineMap(json);
    }

    #endregion

}