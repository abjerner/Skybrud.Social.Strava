using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Meetup.Scopes {

    /// <summary>
    /// Class representing a collection of scopes for the Strava API.
    /// </summary>
    public class StravaScopeCollection : IEnumerable<StravaScope> {

        #region Private fields

        private readonly List<StravaScope> _list = new List<StravaScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all the scopes added to the collection.
        /// </summary>
        public StravaScope[] Items => _list.ToArray();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection based on the specified <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">Array of scopes.</param>
        public StravaScopeCollection(params StravaScope[] array) {
            _list.AddRange(array);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to the collection.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(StravaScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Returns an array of scopes based on the collection.
        /// </summary>
        /// <returns>Array of scopes contained in the location.</returns>
        public StravaScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns an array of strings representing each scope in the collection.
        /// </summary>
        /// <returns>Array of strings representing each scope in the collection.</returns>
        public string[] ToStringArray() {
            return (from scope in _list select scope.Name).ToArray();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An instance of <see cref="IEnumerator{StravaScope}"/>.</returns>
        public IEnumerator<StravaScope> GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representing the scopea added to the collection using a comma as a separator.
        /// </summary>
        /// <returns>String of scopes separated by a comma.</returns>
        public override string ToString() {
            return String.Join(",", from scope in _list select scope.Name);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection based on a single <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope the collection should be based on.</param>
        /// <returns>A new collection based on a single <paramref name="scope"/>.</returns>
        public static implicit operator StravaScopeCollection(StravaScope scope) {
            return new StravaScopeCollection(scope);
        }

        /// <summary>
        /// Initializes a new collection based on an <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">The array of scopes the collection should be based on.</param>
        /// <returns>A new collection based on an <paramref name="array"/> of scopes.</returns>
        public static implicit operator StravaScopeCollection(StravaScope[] array) {
            return new StravaScopeCollection(array ?? new StravaScope[0]);
        }

        /// <summary>
        /// Adds support for adding a <paramref name="scope"/> to the <paramref name="collection"/> using the plus operator.
        /// </summary>
        /// <param name="collection">The collection to which <paramref name="scope"/> will be added.</param>
        /// <param name="scope">The scope to be added to the <paramref name="collection"/>.</param>
        public static StravaScopeCollection operator +(StravaScopeCollection collection, StravaScope scope) {
            collection.Add(scope);
            return collection;
        }

        #endregion

    }

}