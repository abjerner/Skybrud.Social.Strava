using Skybrud.Social.Strava.OAuth;

namespace Skybrud.Social.Strava.Endpoints {

    /// <summary>
    /// Raw implementation of the <strong>Atheletes</strong> endpoint.
    /// </summary>
    public class StravaAtheletesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="StravaOAuthClient"/>.
        /// </summary>
        public StravaOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal StravaAtheletesRawEndpoint(StravaOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        #endregion

    }

}