using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGdotNET.Objects;
using BGGdotNET.Settings;

namespace BGGdotNET.Client
{
    public interface IBGGClient
    {
        //Fetch specific boardgame methods
        List<BoardGame> getBoardGame(params int[] gameIDs);
        List<BoardGame> getBoardGame(BoardGameSettings settings, params int[] gameIDs);

        //Search functionality
        List<BGSearchResult> searchBoardGame(string searchInput);
        List<BGSearchResult> searchBoardGame(SearchSettings settings, string searchInput);

        //GeekList Functionality
        GeekList getGeekList(commentSettings settings, int listID);
        GeekList getGeekList(int listID);

        //Retrieve collection methods
        List<CollectionItem> getUserCollection(CollectionSettings settings, string username);
        List<CollectionItem> getUserCollection(string username);
    }
}
