using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Strava.Models;

/// <summary>
/// Class representing an object received from the Strava API.
/// </summary>
public class StravaObject : JsonObjectBase {

    #region Properties

    /// <summary>
    /// Gets the internal <see cref="JObject"/> the object was created from.
    /// </summary>
    public new JObject JObject => base.JObject!;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
    protected StravaObject(JObject obj) : base(obj) { }

    #endregion

    #region Static methods

    internal static EssentialsTime? ParseIso8601DateTime(string? value) {
        try {
            return string.IsNullOrWhiteSpace(value) ? null : EssentialsTime.FromIso8601(value);
        } catch (Exception ex) {
            throw new ComputerSaysNoException("--" + value + "--" + (value == null) + "--", ex);
        }
    }

    #endregion

}