using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Maps.Geometry;

namespace Skybrud.Social.Strava.Models.Activities;

/// <summary>
/// A pair of latitude/longitude coordinates.
/// </summary>
/// <see>
///     <cref>https://developers.strava.com/docs/reference/#api-models-LatLng</cref>
/// </see>
public class StravaLatLng : IPoint {

    public float Latitude { get; }

    public float Longitude { get; }

    double IPoint.Latitude => Latitude;

    double IPoint.Longitude => Longitude;

    private StravaLatLng(float lat, float lng) {
        Latitude = lat;
        Longitude = lng;
    }

    public static StravaLatLng Parse(JArray array) {
        if (array == null || array.Count < 2) return null;
        return new StravaLatLng((float) array.GetDouble(0), (float) array.GetDouble(1));
    }

}