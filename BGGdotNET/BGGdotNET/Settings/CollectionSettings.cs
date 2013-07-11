using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Settings
{
    /// <summary>
    /// CollectionSettings are used to filter what is returned when enquiring on a user collection.
    /// </summary>
    public class CollectionSettings
    {
        /// <summary>
        /// Collection filter applies a filter on what gets returned by the query
        /// </summary>
        public userCollection collectionFilter { get; set; }

        /// <summary>
        /// withListPriority rerturns games which have the set list priority, valid number is between 1-5
        /// </summary>
        public int wishListPriority { get; set; }

        /// <summary>
        /// minRating only returns games equal or greater than what the user gave it
        /// </summary>
        public int minRating { get; set; }

        /// <summary>
        /// maxRating only returns games equal or less than what the user gave it
        /// </summary>
        public int maxRating { get; set; }

        /// <summary>
        /// Filters games based on what the BGG rating is for a game, must be greater to or equal minBGGRating
        /// </summary>
        public int minBGGRating { get; set; }

        /// <summary>
        /// Filters games based on what the BGG rating is for a game, must be less than or equal minBGGRating
        /// </summary>
        public int maxBGGRating { get; set; }

        /// <summary>
        /// Filters games that have been played at least this or equal to this value
        /// </summary>
        public int minPlays { get; set; }

        /// <summary>
        /// Filters games that have been played less that or equal to this value
        /// </summary>
        public int maxPlays { get; set; }
    }
}
