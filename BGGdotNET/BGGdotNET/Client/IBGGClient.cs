using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGdotNET.Objects;
using BGGdotNET.Enums;

namespace BGGdotNET.Client
{
    public interface IBGGClient
    {
        //Fetch specific boardgame methods
        BoardGame getBoardGame(int gameID);
        List<BoardGame> getBoardGames(int[] gameIDs);

        //Search functionality
        List<BGSearchResult> searchBoardGame(string searchInput);
        List<BGSearchResult> searchBoardGame(searchSettings settings, string searchInput);
    }
}
