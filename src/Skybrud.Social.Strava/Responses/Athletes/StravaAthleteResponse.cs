using Skybrud.Essentials.Http;
using Skybrud.Social.Strava.Models.Athletes;

namespace Skybrud.Social.Strava.Responses.Athletes;

public class StravaAthleteResponse : StravaResponse<StravaAthlete> {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public StravaAthleteResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, StravaAthlete.Parse);
    }

}