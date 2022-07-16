using System;
using Skybrud.Social.Strava.OAuth;

namespace Skybrud.Social.Strava {

    /// <summary>
    /// Class working as an entry point to making requests to the various endpoints of the Strava API.
    /// </summary>
    public class StravaHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying HTTP client.
        /// </summary>
        public StravaOAuthClient Client { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options
        /// </summary>
        public StravaHttpService(StravaOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new instance of <see cref="StravaHttpService"/> based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
        /// <returns>A new instance of <see cref="StravaHttpService"/>.</returns>
        public static StravaHttpService CreateFromClient(StravaOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new StravaHttpService(client);
        }
        
        #endregion

    }

}