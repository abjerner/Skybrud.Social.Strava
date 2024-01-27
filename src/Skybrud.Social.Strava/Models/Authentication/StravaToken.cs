using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Strava.Models.Athletes;

namespace Skybrud.Social.Strava.Models.Authentication;

/// <summary>
/// Class describing an access token received from the Strava API.
/// </summary>
public class StravaToken : StravaObject {

    #region Properties

    public string TokenType { get; }

    public EssentialsTime ExpiresAt { get; }

    public TimeSpan ExpiresIn { get; }

    public string RefreshToken { get; }

    public string AccessToken { get; }

    public StravaAthlete Ahtlete { get; }

    #endregion

    #region Constructors

    private StravaToken(JObject obj) : base(obj) {
        TokenType = obj.GetString("token_type")!;
        ExpiresAt = obj.GetDouble("expires_at", EssentialsTime.FromUnixTimeSeconds)!;
        ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
        RefreshToken = obj.GetString("refresh_token")!;
        AccessToken = obj.GetString("access_token")!;
        Ahtlete = obj.GetObject("athlete", StravaAthlete.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="StravaToken"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="StravaToken"/>.</returns>
    public static StravaToken Parse(JObject obj) {
        return new StravaToken(obj);
    }

    #endregion

}