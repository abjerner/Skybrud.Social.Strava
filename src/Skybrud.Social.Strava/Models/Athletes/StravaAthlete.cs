using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Strava.Models.Athletes;

/// <summary>
///
/// </summary>
/// <see>
///     <cref>https://developers.strava.com/docs/reference/#api-models-SummaryAthlete</cref>
///     <cref>https://developers.strava.com/docs/reference/#api-models-DetailedAthlete</cref>
/// </see>
public class StravaAthlete : StravaObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the athlete.
    /// </summary>
    public long Id { get; }

    public string? Username { get; }

    /// <summary>
    /// Gets the athlete's first name.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the athlete's last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the athlete's city.
    /// </summary>
    public string City { get; }

    /// <summary>
    /// Gets the athlete's state or geographical region.
    /// </summary>
    public string? State { get; }

    /// <summary>
    /// Gets the athlete's country.
    /// </summary>
    public string Country { get; }

    /// <summary>
    /// Gets the athlete's sex. May take one of the following values: <c>M</c>, <c>F</c>
    /// </summary>
    public string? Sex { get; }

    /// <summary>
    /// Gets the athlete's premium status.
    /// </summary>
    public bool IsPremium { get; }

    /// <summary>
    /// Gets the time at which the athlete was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets the time at which the athlete was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    public string? Email { get; }

    #endregion

    #region Constructors

    private StravaAthlete(JObject obj) : base(obj) {
        Id = obj.GetInt64("id");
        Username = obj.GetString("username");
        // TODO: Add support for the "resource_state" property
        FirstName = obj.GetString("firstname")!;
        LastName = obj.GetString("lastname")!;
        // TODO: Add support for the "bio" property (nullable)
        City = obj.GetString("city")!;
        State = obj.GetString("state");
        Country = obj.GetString("country")!;
        Sex = obj.GetString("sex"); // TODO: Either "M" or "F" according to Swagger | not really documented, but both "Non-binary" and "Prefer not to say" are returned as null by the API
        IsPremium = obj.GetBoolean("premium");
        // TODO: Add support for the "summit" property
        CreatedAt = obj.GetString("created_at", ParseIso8601DateTime)!;
        UpdatedAt = obj.GetString("updated_at", ParseIso8601DateTime)!;
        // TODO: Add support for the "badge_type_id" property
        // TODO: Add support for the "weight" property (nullable)
        // TODO: Add support for the "profile_medium" property
        // TODO: Add support for the "profile" property
        // TODO: Add support for the "friend" property (nullable)
        // TODO: Add support for the "follower" property (nullable)
        Email = obj.GetString("email");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="StravaAthlete"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="StravaAthlete"/>.</returns>
    public static StravaAthlete Parse(JObject obj) {
        return new StravaAthlete(obj);
    }

    #endregion

}