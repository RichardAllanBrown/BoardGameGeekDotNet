using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGdotNET.Settings;

namespace BGGdotNET.Client
{
    class UrlBuilder : IUrlBuilder
    {
        private string url = "http://www.boardgamegeek.com/xmlapi";

        public string buildBoardGameUrl(Settings.BoardGameSettings settings, params int[] gameIDs)
        {
            throw new NotImplementedException();
        }

        public string buildSearchUrl(Settings.SearchSettings settings, string searchInput)
        {
            //All spaces must be converted to "%20" for the API
            searchInput.Replace(" ", "%20");

            string requestUrl = url + "/search" + "?search=" + searchInput;

            //The exact argument will only return a single search result
            if (settings == SearchSettings.exact)
            {
                requestUrl = requestUrl + "&exact=1";
            }

            return requestUrl;
        }

        public string buildGeekListUrl(Settings.commentSettings settings, int listID)
        {
            throw new NotImplementedException();
        }

        public string buildUserCollectionUrl(Settings.CollectionSettings settings, string username)
        {
            throw new NotImplementedException();
        }
    }
}
