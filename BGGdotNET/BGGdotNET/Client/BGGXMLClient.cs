using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using BGGdotNET.Client;
using BGGdotNET.Objects;
using BGGdotNET.Enums;

namespace BGGdotNET.Client
{
    public class BGGXMLClient : IBGGClient
    {
        private string url = "http://www.boardgamegeek.com/xmlapi";

        public BoardGame getBoardGame(int gameID)
        {
            throw new NotImplementedException();
        }

        public List<BoardGame> getBoardGames(int[] gameIDs)
        {
            throw new NotImplementedException();
        }

        public List<BGSearchResult> searchBoardGame(string input)
        {
            string searchInput = input;
            List<BGSearchResult> results;

            results = searchBoardGame(searchSettings.notExact, input);

            return results;
        }

        public List<BGSearchResult> searchBoardGame(searchSettings settings, string searchInput)
        {
            //All spaces must be converted to "%20" for the API
            searchInput.Replace(" ", "%20");

            string requestUrl = url + "/search" + "?search=" + searchInput;

            //The exact argument will only return a single search result
            if (settings == searchSettings.exact)
            {
                requestUrl = requestUrl + "&exact=1";
            }

            XDocument result = XDocument.Load(requestUrl);

            var searchResults = from data in result.Descendants("boardgame")
                                select new BGSearchResult
                                {
                                    name = data.Element("name").Value,
                                    yearPublished = int.Parse(data.Element("yearpublished").Value),
                                    ObjectID = (int)data.Attribute("objectid")
                                };

            return searchResults.ToList();
        }
    }
}
