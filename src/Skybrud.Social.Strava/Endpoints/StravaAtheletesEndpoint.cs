namespace Skybrud.Social.Strava.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Atheletes</strong> endpoint.
    /// </summary>
    public class StravaAtheletesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Strava service implementation.
        /// </summary>
        public StravaHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public StravaAtheletesRawEndpoint Raw => Service.Client.Atheletes;

        #endregion

        #region Constructors

        internal StravaAtheletesEndpoint(StravaHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        #endregion

    }

}