using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGGdotNET.Objects;

namespace BGGdotNET.Objects
{
    /// <summary>
    /// This class is used to store the boardgame object that maps to ther XML returned by the API
    /// </summary>
    public class BoardGame
    {
        public int ObjectID { get; set; }
        public int yearPublished { get; set; }
        public int minPlayers { get; set; }
        public int maxPlayers { get; set; }
        public int playingTime { get; set; }
        public int age { get; set; }
        public List<BoardGameName> names { get; set; }
        public string description { get; set; }
        public string imageThumnailURL { get; set; }
        public string imageURL { get; set; }
        public List<BoardGameGeekPair> honors { get; set; }
        public List<BoardGameGeekPair> expansions { get; set; }
        public List<BoardGameGeekPair> categories { get; set; }
        public List<BoardGameGeekPair> publishers { get; set; }
        public List<BoardGameGeekPair> designers { get; set; }
        public List<BoardGameGeekPair> podcasts { get; set; }
        public List<BoardGameGeekPair> mechanics { get; set; }
        public List<BoardGameGeekPair> subdomains { get; set; }
        public List<BoardGameGeekPair> versions { get; set; }
        public List<BoardGamePoll> polls { get; set; }
        public List<BoardGameComment> comments { get; set; }
        public List<BoardGameStats> statistics { get; set; }

        public string getPrimaryName()
        {
            return this.names.First(x => x.isPrimary == true).name;
        }
    }
}
