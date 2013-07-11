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
        /// <summary>
        /// Sets wether to retrieve comments or not for boardgames
        /// </summary>
        public commentSettings commSets { get; set; }

        /// <summary>
        /// Sets what type of statistics to return
        /// </summary>
        public statsSettings statSets { get; set; }

        /// <summary>
        /// If historic stats chosen, this from date will be used to set the date from where they start
        /// </summary>
        public DateTime? historicStatsFrom { get; set; }

        /// <summary>
        /// If historic stats chosen, this to date will be used to set the date they go to
        /// </summary>
        public DateTime? historicStatsTo { get; set; }
    }
}
