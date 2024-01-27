using System;

namespace Skybrud.Social.Strava.Exceptions;

/// <summary>
/// Class representing an exception related to this package.
/// </summary>
public class StravaException : Exception {

    public StravaException(string message) : base(message) { }

}