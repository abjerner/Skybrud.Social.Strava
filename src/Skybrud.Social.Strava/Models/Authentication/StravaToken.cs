﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Strava.Models.Athletes;

namespace Skybrud.Social.Strava.Models.Authentication
{
    /// <summary>
    /// Class describing an access token received from the Strava API.
    /// </summary>
    public class StravaToken : StravaObject {

        #region Properties

        public string AccessToken { get; private set; }

        public string TokenType { get; private set; }

        public StravaAthlete Ahtlete { get; private set; }

        #endregion

        #region Constructors

        private StravaToken(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            Ahtlete = obj.GetObject("athlete", StravaAthlete.Parse);
        }

        #endregion

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="StravaToken"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="StravaToken"/>.</returns>
        public static StravaToken Parse(JObject obj) {
            return obj == null ? null : new StravaToken(obj);
        }

    }

}