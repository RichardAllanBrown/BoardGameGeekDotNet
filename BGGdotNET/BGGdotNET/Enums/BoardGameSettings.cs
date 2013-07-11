using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Enums
{
    /// <summary>
    /// This class is used to store settings for the getBoardGame client call
    /// </summary>
    /// <remarks>historicStatsFrom and historicStastTo should be set if and only if statSets = historic</remarks>
    public class BoardGameSettings
    {
        public commentSettings commSets { get; set; }
        public statsSettings statSets { get; set; }
        public DateTime? historicStatsFrom { get; set; }
        public DateTime? historicStatsTo { get; set; }
    }
}
