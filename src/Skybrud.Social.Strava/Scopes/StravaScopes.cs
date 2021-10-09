namespace Skybrud.Social.Meetup.Scopes {

    /// <summary>
    /// Static class with properties representing scopes of available for the Strava API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.strava.com/docs/authentication/#request-access</cref>
    /// </see>
    public static class StravaScopes {

        public static readonly StravaScope Public = new StravaScope("public");

        public static readonly StravaScope Write = new StravaScope("write");

        public static readonly StravaScope ViewPrivate = new StravaScope("view_private");

    }

}