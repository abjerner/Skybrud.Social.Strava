using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Strava.Models;

/// <summary>
/// Class representing an object received from the Strava API.
/// </summary>
public class StravaObject : JsonObjectBase {

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
    protected StravaObject(JObject obj) : base(obj) { }

    #endregion

}