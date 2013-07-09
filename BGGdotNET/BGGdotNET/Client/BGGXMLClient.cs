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

        public List<BoardGame> getBoardGame(params int[] gameIDs)
        {
            StringBuilder sb = new StringBuilder(url);

            sb.Append("/boardgame/");

            foreach(int parm in gameIDs)
            {
                sb.Append(parm);
            }

            string requestUrl = sb.ToString();

            XDocument result = XDocument.Load(requestUrl);

            var boardgames = from data in result.Descendants("boardgame")
                             select new BoardGame
                             {
                                 age = int.Parse(data.Element("age").Value),
                                 description = data.Element("description").Value,
                                 imageThumnailURL = data.Element("thumbnail").Value,
                                 imageURL = data.Element("image").Value,
                                 maxPlayers = int.Parse(data.Element("maxplayers").Value),
                                 minPlayers = int.Parse(data.Element("minplayers").Value),
                                 ObjectID = (int)data.Attribute("objectid"),
                                 //playingTime = int.Parse(data.Attribute("playingtime").Value),  //THROWS EXCEPTION, WHY?
                                 yearPublished = int.Parse(data.Element("yearpublished").Value),
                                 categories = (from cat in data.Elements("boardgamecategory")
                                              select new BoardGameGeekPair
                                              {
                                                  value = cat.Value,
                                                  objectID = (int)cat.Attribute("objectid")
                                              }).ToList()
                             };

            return boardgames.ToList();
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
                                    ObjectID = (int) data.Attribute("objectid")
                                };

            return searchResults.ToList();
        }
    }
}
