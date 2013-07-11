using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Enums
{
        /// <summary>
        /// Comment Settings will either fetch or leave the comments against a boardgame.
        /// </summary>
        public enum commentSettings { none, fetch };

        /// <summary>
        /// Stats settings are used to control retreival of statistics.  
        /// Current fetched most up to date, historic will fetch a range.
        /// </summary>
        public enum statsSettings { none, current, histroic };

        /// <summary>
        /// Choosing a usercollection setting will limit what is returned for a user.
        /// </summary>
        public enum userCollection { own, rated, played, comment, trade, want, wishlist, wantToPlay, preOwned, preOrdered, hasParts, wantParts, notifyContent, notifySale, notifyAuction, wishlistPriority }

        /// <summary>
        /// Search settings can be exact which only returns one, when it's exactly right.
        /// </summary>
        public enum SearchSettings { exact, notExact };
}
