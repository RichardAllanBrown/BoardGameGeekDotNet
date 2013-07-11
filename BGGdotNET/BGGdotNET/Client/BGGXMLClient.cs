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
            return getBoardGame(null, gameIDs);
        }

        public List<BoardGame> getBoardGame(BoardGameSettings settings, params int[] gameIDs)
        {
            StringBuilder sb = new StringBuilder(url);

            sb.Append("/boardgame/");

            foreach(int parm in gameIDs)
            {
                sb.Append(parm);

                //Game numbers need to be delimited by commas if there are many
                if (gameIDs.Length > 0 && parm != gameIDs[gameIDs.Length - 1])
                {
                    sb.Append(",");
                }
            }

            if (settings != null)
            {
                sb.Append("?");

                if (settings.commSets == commentSettings.fetch)
                {
                    sb.Append("comments=1");
                }
                else
                {
                    sb.Append("comments=0");
                }

                sb.Append("&");

                if (settings.statSets == statsSettings.current)
                {
                    sb.Append("stats=1");
                }
                else if (settings.statSets == statsSettings.histroic)
                {
                    sb.Append("historical=1");

                    if (settings.historicStatsFrom != null || settings.historicStatsTo != null)
                    {
                        if (settings.historicStatsTo == null)
                        {
                            settings.historicStatsTo = DateTime.Now;
                            
                        }

                        if (settings.historicStatsFrom == null)
                        {
                            settings.historicStatsFrom = new DateTime(2006, 03, 18);
                        }

                        DateTime to = (DateTime)settings.historicStatsTo;
                        DateTime from = (DateTime)settings.historicStatsFrom;

                        sb.Append("&from=" + from.ToString("yyyy-MM-dd") + "&to=" + to.ToString("yyy-MM-dd"));
                    }
                }
                else
                {
                    sb.Append("stats=0");
                }
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

                                 yearPublished = int.Parse(data.Element("yearpublished").Value),

                                 categories = (from cat in data.Elements("boardgamecategory")
                                              select new BoardGameGeekPair
                                              {
                                                  value = cat.Value,
                                                  objectID = (int)cat.Attribute("objectid")
                                              }).ToList(),

                                 designers = (from des in data.Elements("boardgamedesigner")
                                             select new BoardGameGeekPair
                                             {
                                                 value = des.Value,
                                                 objectID = (int)des.Attribute("objectid")
                                             }).ToList(),

                                 expansions = (from exp in data.Elements("boardgameexpansion")
                                             select new BoardGameGeekPair
                                             {
                                                 value = exp.Value,
                                                 objectID = (int)exp.Attribute("objectid")
                                             }).ToList(),

                                 honors = (from hon in data.Elements("boardgamehonor")
                                           select new BoardGameGeekPair
                                           {
                                               value = hon.Value,
                                               objectID = (int)hon.Attribute("objectid")
                                           }).ToList(),

                                 mechanics = (from mec in data.Elements("boardgamemechanic")
                                              select new BoardGameGeekPair
                                              {
                                                  value = mec.Value,
                                                  objectID = (int)mec.Attribute("objectid")
                                              }).ToList(),

                                 names = (from name in data.Elements("name")
                                          select new BoardGameName
                                          {
                                              name = name.Value,
                                              sortIndex = (int)name.Attribute("sortindex")
                                          }).ToList(),

                                 podcasts = (from pod in data.Elements("boardgamepodcastepisode")
                                             select new BoardGameGeekPair
                                             {
                                                 value = pod.Value,
                                                 objectID = (int)pod.Attribute("objectid")
                                             }).ToList(),

                                 publishers = (from pub in data.Elements("boardgamepublisher")
                                               select new BoardGameGeekPair
                                               {
                                                   value = pub.Value,
                                                   objectID = (int)pub.Attribute("objectid")
                                               }).ToList(),

                                 subdomains = (from sub in data.Elements("boardgamesubdomain")
                                               select new BoardGameGeekPair
                                               {
                                                   value = sub.Value,
                                                   objectID = (int)sub.Attribute("objectid")
                                               }).ToList(),

                                 versions = (from ver in data.Elements("boardgameversion")
                                             select new BoardGameGeekPair
                                             {
                                                 value = ver.Value,
                                                 objectID = (int)ver.Attribute("objectid")
                                             }).ToList(),

                                 comments = (from com in data.Elements("comment")
                                             select new BoardGameComment
                                             {
                                                 username = (string)com.Attribute("username"),
                                                 comment = com.Value
                                             }).ToList(),

                                 polls = (from pol in data.Elements("poll")
                                          select new BoardGamePoll
                                          {
                                              pollName = (string)pol.Attribute("name"),
                                              pollTitle = (string)pol.Attribute("title"),
                                              totalVotes = (int)pol.Attribute("totalvotes"),
                                              resultsList = (from res in data.Elements("results")
                                                             select new BoardGamePollResult
                                                             {
                                                                 responseValue = (string)res.Attribute("value"),
                                                                 voteCount = (int) res.Attribute("numvotes")
                                                             }).ToList()
                                          }).ToList()
                             };

            return boardgames.ToList();
        }

        public List<BGSearchResult> searchBoardGame(string input)
        {
            string searchInput = input;
            List<BGSearchResult> results;

            results = searchBoardGame(SearchSettings.notExact, input);

            return results;
        }

        public List<BGSearchResult> searchBoardGame(SearchSettings settings, string searchInput)
        {
            //All spaces must be converted to "%20" for the API
            searchInput.Replace(" ", "%20");

            string requestUrl = url + "/search" + "?search=" + searchInput;

            //The exact argument will only return a single search result
            if (settings == SearchSettings.exact)
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
