using System;
using System.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Strava.Endpoints;
using Skybrud.Social.Strava.Responses.Authentication;
using Skybrud.Social.Strava.Scopes;

namespace Skybrud.Social.Strava.OAuth {

    public class StravaOAuthClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the client ID of the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the app.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Athletes</strong> endpoint.
        /// </summary>
        public StravaAthletesRawEndpoint Athletes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public StravaOAuthClient() {
            Athletes = new StravaAthletesRawEndpoint(this);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and the default scope.
        /// </summary>
        /// <param name="state">The state to send to Meetups's OAuth login page.</param>
        /// <returns>An authorization URL based on <paramref name="state"/>.</returns>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, StravaApprovalPrompt.Auto, default(StravaScopeList));
        }
        
        public string GetAuthorizationUrl(string state, StravaScope scope) {
            return GetAuthorizationUrl(state, StravaApprovalPrompt.Auto, scope == null ? null : new StravaScopeList(scope));
        }

        public string GetAuthorizationUrl(string state, params StravaScope[] scope) {
            return GetAuthorizationUrl(state, StravaApprovalPrompt.Auto, scope == null ? null : new StravaScopeList(scope));
        }

        public string GetAuthorizationUrl(string state, StravaScopeList scope) {
            return GetAuthorizationUrl(state, StravaApprovalPrompt.Auto, scope);
        }
        
        public string GetAuthorizationUrl(string state, StravaApprovalPrompt approvalPrompt, StravaScope scope) {
            return GetAuthorizationUrl(state, approvalPrompt, scope == null ? null : new StravaScopeList(scope));
        }
        
        public string GetAuthorizationUrl(string state, StravaApprovalPrompt approvalPrompt, params StravaScope[] scope) {
            return GetAuthorizationUrl(state, approvalPrompt, scope == null ? null : new StravaScopeList(scope));
        }

        public string GetAuthorizationUrl(string state, StravaApprovalPrompt approvalPrompt, StravaScopeList scope) {

            // Some validation
            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));

            // Do we have a valid "state" ?
            if (string.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException(nameof(state), "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            IHttpQueryString query = new HttpQueryString();
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("response_type", "code");
            query.Add("state", state);

            if (scope != null && scope.Any()) query.Add("scope", scope + "");

            if (approvalPrompt == StravaApprovalPrompt.Force) query.Add("approval_prompt", "force");

            // Generate the authorization URL
            return "https://www.strava.com/oauth/authorize?" + query;

        }

        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Strava OAuth dialog.</param>
        /// <returns>An instance of <see cref="StravaTokenResponse"/> representing the response.</returns>
        public StravaTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Some validation
            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (string.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize the query string
            IHttpPostData data = new HttpPostData {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"code", authCode},
                {"grant_type", "authorization_code"}
            };

            // Make the call to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://www.strava.com/api/v3/oauth/token", data);

            // Parse the response
            return new StravaTokenResponse(response);

        }

        /// <summary>
        /// Exchanges the specified refresh token for an access token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>An instance of <see cref="StravaTokenResponse"/> representing the response.</returns>
        public StravaTokenResponse GetAccessTokenFromRefereshToken(string refreshToken) {

            // Some validation
            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (string.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

            // Initialize the query string
            IHttpPostData data = new HttpPostData {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"grant_type", "refresh_token"},
                {"refresh_token", refreshToken}
            };

            // Make the call to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://www.strava.com/api/v3/oauth/token", data);

            // Parse the response
            return new StravaTokenResponse(response);

        }

        #endregion

    }

}