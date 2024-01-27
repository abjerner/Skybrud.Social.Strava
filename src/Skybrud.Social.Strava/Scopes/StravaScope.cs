using System.Collections.Generic;

namespace Skybrud.Social.Strava.Scopes;

/// <summary>
/// Class representing a scope of the Strava API.
/// </summary>
public class StravaScope {

    #region Private fields

    private static readonly Dictionary<string, StravaScope> Scopes = new Dictionary<string, StravaScope>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the alias of the scope.
    /// </summary>
    public string Alias { get; }

    /// <summary>
    /// Gets the name of the scope.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the scope.
    /// </summary>
    public string Description { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new scope with the specified <paramref name="alias"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="alias">The name of the scope.</param>
    /// <param name="name">The name of the scope.</param>
    public StravaScope(string alias, string name) {
        Alias = alias;
        Name = name;
        Description = string.Empty;
    }

    /// <summary>
    /// Initializes a new scope with the specified <paramref name="alias"/>, <paramref name="name"/> and <paramref name="description"/>.
    /// </summary>
    /// <param name="alias">The name of the scope.</param>
    /// <param name="name">The name of the scope.</param>
    /// <param name="description">The description of the scope.</param>
    public StravaScope(string alias, string name, string description) {
        Alias = alias;
        Name = name;
        Description = description?.Trim() ?? string.Empty;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a string representation of the scope.
    /// </summary>
    /// <returns>The name of the scope.</returns>
    public override string ToString() {
        return Alias;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Registers a scope in the internal dictionary.
    /// </summary>
    /// <param name="name">The name of the scope.</param>
    internal static StravaScope RegisterScope(string name) {
        StravaScope scope = new StravaScope(name, null);
        Scopes.Add(scope.Alias, scope);
        return scope;
    }

    /// <summary>
    /// Registers a scope in the internal dictionary.
    /// </summary>
    /// <param name="name">The name of the scope.</param>
    /// <param name="description">The description of the scope.</param>
    internal static StravaScope RegisterScope(string name, string description) {
        StravaScope scope = new StravaScope(name, description);
        Scopes.Add(scope.Alias, scope);
        return scope;
    }

    /// <summary>
    /// Attempts to get a scope with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="alias">The alias of the scope.</param>
    /// <returns>Gets a scope matching the specified <paramref name="alias"/>, or <c>null</c> if not found.</returns>
    public static StravaScope GetScope(string alias) {
        return Scopes.TryGetValue(alias, out StravaScope scope) ? scope : null;
    }

    /// <summary>
    /// Gets whether the scope is a known scope.
    /// </summary>
    /// <param name="alias">The alias of the scope.</param>
    /// <returns><c>true</c> if the specified <paramref name="alias"/> matches a known scope, otherwise <c>false</c>.</returns>
    public static bool ScopeExists(string alias) {
        return Scopes.ContainsKey(alias);
    }

    #endregion

    #region Operators

    /// <summary>
    /// Adding two instances of <see cref="StravaScope"/> will result in a <see cref="StravaScopeList"/>
    /// containing both scopes.
    /// </summary>
    /// <param name="left">The left scope.</param>
    /// <param name="right">The right scope.</param>
    public static StravaScopeList operator +(StravaScope left, StravaScope right) {
        return new StravaScopeList(left, right);
    }

    #endregion

}