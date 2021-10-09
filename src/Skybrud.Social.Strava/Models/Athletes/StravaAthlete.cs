using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Strava.Models.Athletes {

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
        public long Id { get; private set; }

        public string Username { get; private set; }

        /// <summary>
        /// Gets the athlete's first name.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the athlete's last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the athlete's city.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Gets the athlete's state or geographical region.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Gets the athlete's country.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Gets the athlete's sex. May take one of the following values: <c>M</c>, <c>F</c>
        /// </summary>
        public string Sex { get; private set; }

        /// <summary>
        /// Gets the athlete's premium status.
        /// </summary>
        public bool IsPremium { get; private set; }

        /// <summary>
        /// Gets the time at which the athlete was created.
        /// </summary>
        public EssentialsDateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time at which the athlete was last updated.
        /// </summary>
        public EssentialsDateTime UpdatedAt { get; private set; }

        public string Email { get; private set; }

        #endregion

        #region Constructors

        private StravaAthlete(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Username = obj.GetString("username");
            // TODO: Add support for the "resource_state" property
            FirstName = obj.GetString("firstname");
            LastName = obj.GetString("lastname");
            City = obj.GetString("city");
            State = obj.GetString("state");
            Country = obj.GetString("country");
            Sex = obj.GetString("sex");
            Username = obj.GetString("username");
            IsPremium = obj.GetBoolean("premium");
            CreatedAt = obj.GetDateTime("created_at");
            UpdatedAt = obj.GetDateTime("updated_at");
            // TODO: Add support for the "badge_type_id" property
            // TODO: Add support for the "profile_medium" property
            // TODO: Add support for the "profile" property
            // TODO: Add support for the "friend" property
            // TODO: Add support for the "follower" property
            Email = obj.GetString("email");
        }

        #endregion

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="StravaAthlete"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="StravaAthlete"/>.</returns>
        public static StravaAthlete Parse(JObject obj) {
            return obj == null ? null : new StravaAthlete(obj);
        }

    }

}