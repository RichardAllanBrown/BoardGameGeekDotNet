using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Objects
{
    public class CollectionItem
    {
        public string objecttype { get; set; }
        public int objectID { get; set; }
        public string subType { get; set; }
        public int collID { get; set; }
        public string name { get; set; }
        public int yearPublished { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }

        //Statistics
        public int minPlayers { get; set; }
        public int maxPlayers { get; set; }
        public int playingTime { get; set; }
        public int numOwned { get; set; }
        public int rating { get; set; }
        public int userRated { get; set; }
        public float average { get; set; }
        public float bayesAverage { get; set; }
        public float standardDeviation { get; set; }
        public int median { get; set; }

        //User status
        public int own { get; set; }
        public int prevOwned { get; set; }
        public int forTrade { get; set; }
        public int want { get; set; }
        public int wantToPlay { get; set; }
        public int wantToBuy { get; set; }
        public int wishlist { get; set; }
        public int preOrdered { get; set; }
        public DateTime lastModified { get; set; }

        public int numPlays { get; set; }
    }
}
