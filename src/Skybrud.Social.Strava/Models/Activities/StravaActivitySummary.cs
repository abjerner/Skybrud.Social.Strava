using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Strava.Models.Activities {
    
    public class StravaActivitySummary : StravaObject {

        #region Properties

        /// <summary>
        /// Gets the unique identifier of the activity.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the identifier provided at upload time.
        /// </summary>
        public string ExternalId { get; }

        /// <summary>
        /// Gets the identifier of the upload that resulted in this activity.
        /// </summary>
        public long UploadId { get; }

        //public StravaAthleteMeta Athlete { get; }

        /// <summary>
        /// Gets the name of the activity.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the activity's distance, in meters.
        /// </summary>
        public float Distance { get; }

        /// <summary>
        /// Gets the activity's moving time, in seconds.
        /// </summary>
        public TimeSpan MovingTime { get; }

        /// <summary>
        /// Gets the activity's elapsed time, in seconds.
        /// </summary>
        public TimeSpan ElapsedTime { get; }

        /// <summary>
        /// Gets the type of the activity.
        /// </summary>
        public StravaActivityType Type { get; }

        /// <summary>
        /// Gets the time at which the activity was started.
        /// </summary>
        public EssentialsTime StartDate { get; }

        /// <summary>
        /// Gets the time at which the activity was started in the local timezone.
        /// </summary>
        public EssentialsTime StartDateLocal { get; }

        /// <summary>
        /// Gets the timezone of the activity.
        /// </summary>
        public string TimeZone { get; }

        /// <summary>
        /// Gets the starting point of the activity.
        /// </summary>
        public StravaLatLng StartLatLng { get; }

        /// <summary>
        /// Gets the ending point of the activity.
        /// </summary>
        public StravaLatLng EndLatLng { get; }

        /// <summary>
        /// Gets the number of achievements gained during this activity.
        /// </summary>
        public int AchievementCount { get; }

        /// <summary>
        /// Gets the number of kudos given for this activity.
        /// </summary>
        public int KudosCount { get; }

        /// <summary>
        /// Gets the number of comments for this activity.
        /// </summary>
        public int CommentCount { get; }

        /// <summary>
        /// Gets the number of athletes for taking part in a group activity.
        /// </summary>
        public int AthleteCount { get; }

        /// <summary>
        /// Gets the number of Instagram photos for this activity.
        /// </summary>
        public int PhotoCount { get; }

        /// <summary>
        /// Gets the number of Instagram and Strava photos for this activity.
        /// </summary>
        public int TotalPhotoCount { get; }

        /// <summary>
        /// Gets an instance of <see cref="StravaPolylineMap"/>.
        /// </summary>
        public StravaPolylineMap Map { get; }

        /// <summary>
        /// Gets the activity's workout type.
        /// </summary>
        public int WorkoutType { get; }

        /// <summary>
        /// Gets the activity's average speed, in meters per second.
        /// </summary>
        public float AverageSpeed { get; }

        /// <summary>
        /// Gets the activity's max speed, in meters per second.
        /// </summary>
        public float MaxSpeed { get; }

        #endregion

        #region Constructors

        private StravaActivitySummary(JObject json) : base(json) {
            Id = json.GetInt64("id");
            ExternalId = json.GetString("external_id");
            UploadId = json.GetInt64("upload_id");
            Name = json.GetString("name");
            Distance = json.GetFloat("distance");
            MovingTime = json.GetDouble("moving_time", TimeSpan.FromSeconds);
            ElapsedTime = json.GetDouble("elapsed_time", TimeSpan.FromSeconds);
            Type = json.GetEnum<StravaActivityType>("type");
            StartDate = json.GetString("start_date", EssentialsTime.Parse);
            StartDateLocal = json.GetString("start_date_local", EssentialsTime.Parse);
            TimeZone = json.GetString("timezone");
            StartLatLng = StravaLatLng.Parse(json.GetArray("start_latlng"));
            EndLatLng = StravaLatLng.Parse(json.GetArray("end_latlng"));
            AchievementCount = json.GetInt32("achievement_count");
            KudosCount = json.GetInt32("kudos_count");
            CommentCount = json.GetInt32("comment_count");
            AthleteCount = json.GetInt32("athlete_count");
            PhotoCount = json.GetInt32("photo_count");
            TotalPhotoCount = json.GetInt32("total_photo_count");
            Map = json.GetObject("map", StravaPolylineMap.Parse);
            WorkoutType = json.GetInt32("workout_type");
            AverageSpeed = json.GetFloat("average_speed");
            MaxSpeed = json.GetFloat("max_speed");
        }

        #endregion

        #region Static methods

        public static StravaActivitySummary Parse(JObject json) {
            return json == null ? null : new StravaActivitySummary(json);
        }

        #endregion

    }

}