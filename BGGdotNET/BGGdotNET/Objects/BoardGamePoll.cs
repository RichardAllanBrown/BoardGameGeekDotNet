using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Objects
{
    /// <summary>
    /// BoardGamePolls are attached to board games, they will have 1 to n results within them
    /// </summary>
    public class BoardGamePoll
    {
        public string pollName { get; set; }
        public string pollTitle { get; set; }
        public int totalVotes { get; set; }
        public List<BoardGamePollResult> resultsList { get; set; }
    }


    /// <summary>
    /// BoardGameRPollResult contains the responses and the number of votes for that response in a poll
    /// </summary>
    public class BoardGamePollResult
    {
        public int level { get; set; }
        public string responseValue { get; set; }
        public int voteCount { get; set; }
    }
}
