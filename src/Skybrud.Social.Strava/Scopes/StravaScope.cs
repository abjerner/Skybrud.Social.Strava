using System;
using System.Collections.Generic;

namespace Skybrud.Social.Meetup.Scopes {
    
    /// <summary>
    /// Class representing a scope of the Strava API.
    /// </summary>
    public class StravaScope {

        #region Private fields

        private static readonly Dictionary<string, StravaScope> Scopes = new Dictionary<string, StravaScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public StravaScope(string name) {
            Name = name;
            Description = String.Empty;
        }

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public StravaScope(string name, string description) {
            Name = name;
            Description = String.IsNullOrWhiteSpace(description) ? String.Empty : description.Trim();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation of the scope.
        /// </summary>
        /// <returns>The name of the scope.</returns>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static StravaScope RegisterScope(string name, string description = null) {
            StravaScope scope = new StravaScope(name, description);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <paramref name="name"/>, or <c>null</c> if not found.</returns>
        public static StravaScope GetScope(string name) {
            StravaScope scope;
            return Scopes.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="name"/> matches a known scope, otherwise <c>false</c>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="StravaScope"/> will result in a <see cref="StravaScopeCollection"/>
        /// containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static StravaScopeCollection operator +(StravaScope left, StravaScope right) {
            return new StravaScopeCollection(left, right);
        }

        #endregion

    }

}