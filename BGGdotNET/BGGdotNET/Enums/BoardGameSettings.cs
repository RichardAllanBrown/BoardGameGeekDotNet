using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Enums
{
    /// <summary>
    /// Comment Settings will either fetch or leave the comments against a boardgame
    /// </summary>
    public enum commentSettings { none, fetch };

    /// <summary>
    /// Stats settings are used to control retreival of statistics.  
    /// Current fetched most up to date, historic will fetch a range.
    /// </summary>
    public enum statsSettings { none, current, histroic };

    /// <summary>
    /// This class is used to store settings for the getBoardGame client call
    /// </summary>
    /// <remarks>historicStatsFrom and histociStastTo should be set if and only if statSets = historic</remarks>
    class BoardGameSettings
    {
        public commentSettings commSets { get; set; }
        public statsSettings statSets { get; set; }
        public DateTime historicStatsFrom { get; set; }
        public DateTime historicStatsTo { get; set; }
    }
}
