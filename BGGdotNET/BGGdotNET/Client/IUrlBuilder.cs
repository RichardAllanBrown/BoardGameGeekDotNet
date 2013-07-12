using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGdotNET.Client;
using BGGdotNET.Objects;
using BGGdotNET.Settings;

namespace BGGdotNET.Client
{
    public interface IUrlBuilder
    {
        string buildBoardGameUrl(BoardGameSettings settings, params int[] gameIDs);
        string buildSearchUrl(SearchSettings settings, string searchInput);
        string buildGeekListUrl(commentSettings settings, int listID);
        string buildUserCollectionUrl(CollectionSettings settings, string username);
    }
}
