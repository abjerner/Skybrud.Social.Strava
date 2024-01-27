namespace Skybrud.Social.Strava.Scopes;

/// <summary>
/// Static class with properties representing scopes of available for the Strava API.
/// </summary>
/// <see>
///     <cref>https://developers.strava.com/docs/authentication/#requestingaccess</cref>
/// </see>
public static class StravaScopes {

    public static readonly StravaScope Read = new StravaScope(
        "read",
        "Read",
        "Read public segments, public routes, public profile data, public posts, public events, club " +
        "feeds, and leaderboards."
    );

    public static readonly StravaScope ReadAll = new StravaScope(
        "read_all",
        "Read all",
        "Read private routes, private segments, and private events for the user."
    );

    public static readonly StravaScope ProfileReadAll = new StravaScope(
        "profile:read_all",
        "Profile: Read all",
        "Read all profile information even if the user has set their profile visibility to Followers or Only You."
    );

    public static readonly StravaScope ProfileWrite = new StravaScope(
        "profile:write",
        "Profile: Write",
        "Update the user's weight and Functional Threshold Power (FTP), and access to star or unstar segments on their behalf."
    );

    public static readonly StravaScope ActivityRead = new StravaScope(
        "activity:read",
        "Activity: Read",
        "Read the user's activity data for activities that are visible to Everyone and Followers, excluding privacy zone data."
    );

    public static readonly StravaScope ActivityReadAll = new StravaScope(
        "activity:read_all",
        "Activity: Read all",
        "The same access as <code>activity:read</code>, plus privacy zone data and access to read the user's activities with visibility set to Only You."
    );

    public static readonly StravaScope ActivityWrite = new StravaScope(
        "activity:write",
        "Activity: Read",
        "Access to create manual activities and uploads, and access to edit any activities that are visible to the app, based on activity read access level."
    );

    public static readonly StravaScope[] All = {
        Read,
        ReadAll,
        ProfileReadAll,
        ProfileWrite,
        ActivityRead,
        ActivityReadAll,
        ActivityWrite
    };

}