using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Strava.Models.Clubs;

/// <summary>
/// Class with detailed information about a Strava club.
/// </summary>
/// <see>
///     <cref>https://developers.strava.com/docs/reference/#api-models-DetailedClub</cref>
/// </see>
/// .
public class StravaDetailedClub : StravaObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the club.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the name of the club.
    /// </summary>
    public string Name { get; }

    public StravaClubSportType SportType { get; }

    public int MemberCount { get; }

    #endregion

    #region Constructors

    private StravaDetailedClub(JObject obj) : base(obj) {
        Id = obj.GetInt64("id");
        // TODO: Add support for the "resource_state" property
        Name = obj.GetString("name")!;
        // TODO: Add support for the "profile_medium" property
        // TODO: Add support for the "cover_photo" property
        // TODO: Add support for the "cover_photo_small" property
        SportType = obj.GetEnum<StravaClubSportType>("sport_type");
        // TODO: Add support for the "city" property
        // TODO: Add support for the "state" property
        // TODO: Add support for the "country" property
        // TODO: Add support for the "private" property
        MemberCount = obj.GetInt32("member_count");
        // TODO: Add support for the "featured" property
        // TODO: Add support for the "verified" property
        // TODO: Add support for the "url" property
        // TODO: Add support for the "membership" property
        // TODO: Add support for the "admin" property
        // TODO: Add support for the "owner" property
        // TODO: Add support for the "following_count" property
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="StravaDetailedClub"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="StravaDetailedClub"/>.</returns>
    public static StravaDetailedClub Parse(JObject obj) {
        return new StravaDetailedClub(obj);
    }

    #endregion

}