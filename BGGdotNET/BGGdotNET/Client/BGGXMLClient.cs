using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using BGGdotNET.Client;
using BGGdotNET.Objects;
using BGGdotNET.Settings;

namespace BGGdotNET.Client
{
    public class BGGXMLClient : IBGGClient
    {
        private string url = "http://www.boardgamegeek.com/xmlapi";
        private IUrlBuilder builder = new UrlBuilder();

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

                                 statistics = (from stat in data.Element("statistics").Elements("ratings")
                                               select new BoardGameStats
                                               {
                                                   average = (float)stat.Element("average"),
                                                   averageWeight = (float)stat.Element("averageweight"),
                                                   bayesAverage = (float)stat.Element("bayesaverage"),
                                                   median = (float)stat.Element("median"),
                                                   numComments = (int)stat.Element("numcomments"),
                                                   numWeights = (int)stat.Element("numweights"),
                                                   owned = (int)stat.Element("owned"),
                                                   trading = (int)stat.Element("trading"),
                                                   standardDeviation = (float)stat.Element("stddev"),
                                                   usersRated = (int)stat.Element("usersrated"),
                                                   wanting = (int)stat.Element("wanting"),
                                                   wishing = (int)stat.Element("wishing"),
                                                   ranks = (from ranks in stat.Elements("ranks")
                                                            select new BoardGameRank
                                                            {
                                                                name = (string)ranks.Attribute("name"),
                                                                friendlyName = (string)ranks.Attribute("friendlyname"),
                                                                type = (string)ranks.Attribute("type")
                                                            }).ToList()
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
            string requestUrl = builder.buildSearchUrl(settings, searchInput);

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

        public GeekList getGeekList(int listID)
        {
            return getGeekList(commentSettings.none, listID);
        }

        public GeekList getGeekList(commentSettings settings, int listID)
        {
            string requestUrl = builder.buildGeekListUrl(settings, listID);

            XDocument result = XDocument.Load(requestUrl);

            var geekListResult = from data in result.Descendants("geeklist")
                                 select new GeekList
                                 {
                                     description = data.Element("description").Value,
                                     id = (int)data.Attribute("id"),
                                     numItems = int.Parse(data.Element("numitems").Value),
                                     editDateTimestamp = data.Element("editdate_timestamp").Value,
                                     postDateTimestamp = data.Element("postdate_timestamp").Value,
                                     thumbs = int.Parse(data.Element("thumbs").Value),
                                     title = data.Element("title").Value,
                                     userName = data.Element("username").Value,
                                     
                                     comments = (from com in data.Descendants("comment")
                                                 select new GeekListComment
                                                 {
                                                     username = com.Attribute("username").Value,
                                                     thumbs = int.Parse(com.Attribute("thumbs").Value),
                                                     commentText = com.Value
                                                 }).ToList(),

                                     items = (from it in data.Descendants("item")
                                             select new GeekListItem
                                             {
                                                 id = int.Parse(it.Attribute("id").Value),
                                                 objectType = it.Attribute("objecttype").Value,
                                                 subType = it.Attribute("subtype").Value,
                                                 objectID = int.Parse(it.Attribute("objectid").Value),
                                                 objectName = it.Attribute("objectname").Value,
                                                 userName = it.Attribute("username").Value,
                                                 thumbs = int.Parse(it.Attribute("thumbs").Value),
                                                 imageID = int.Parse(it.Attribute("imageid").Value),
                                                 comments = (from com in data.Descendants("comment")
                                                             select new GeekListComment
                                                             {
                                                                 username = com.Attribute("username").Value,
                                                                 thumbs = int.Parse(com.Attribute("thumbs").Value),
                                                                 commentText = com.Value
                                                             }).ToList()
                                             }).ToList()
                                 };

            return geekListResult.FirstOrDefault();
        }

        public List<CollectionItem> getUserCollection(string username)
        {
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all
            };

            return getUserCollection(set, username);
        }

        public List<CollectionItem> getUserCollection(CollectionSettings settings, string username)
        {
            StringBuilder sb = new StringBuilder(url);

            sb.Append("/collection/");
            sb.Append(username);

            List<string> parameters = new List<string>();

            switch (settings.collectionFilter)
            {
                case userCollection.own:
                    parameters.Add("own=1");
                    break;

                case userCollection.rated:
                    parameters.Add("rated=1");
                    break;

                case userCollection.played:
                    parameters.Add("player=1");
                    break;

                case userCollection.comment:
                    parameters.Add("comment=1");
                    break;

                case userCollection.trade:
                    parameters.Add("trade=1");
                    break;

                case userCollection.want:
                    parameters.Add("want=1");
                    break;

                case userCollection.wishlist:
                    parameters.Add("wishlist=1");
                    break;

                case userCollection.wantToPlay:
                    parameters.Add("wanttoplay=1");
                    break;

                case userCollection.wantToBuy:
                    parameters.Add("wanttobuy=1");
                    break;

                case userCollection.preOwned:
                    parameters.Add("prevowned=1");
                    break;

                case userCollection.preOrdered:
                    parameters.Add("preordered=1");
                    break;

                case userCollection.hasParts:
                    parameters.Add("hasparts=1");
                    break;

                case userCollection.wantParts:
                    parameters.Add("wantparts=1");
                    break;

                case userCollection.notifyContent:
                    parameters.Add("notifycontent=1");
                    break;

                case userCollection.notifySale:
                    parameters.Add("notifysale=1");
                    break;

                case userCollection.notifyAuction:
                    parameters.Add("notifyauction=1");
                    break;

                case userCollection.wishlistPriority:
                    parameters.Add("wishlistpriority=" + settings.wishListPriority);
                    break;
            }

            if (settings.maxBGGRating > 0)
            {
                parameters.Add("maxbggrating=" + settings.maxBGGRating);
            }

            if (settings.maxPlays > 0)
            {
                parameters.Add("maxplays=" + settings.maxPlays);
            }

            if (settings.maxRating > 0)
            {
                parameters.Add("maxrating=" + settings.maxRating);
            }

            if (settings.minBGGRating > 0)
            {
                parameters.Add("minbggrating=" + settings.minBGGRating);
            }

            if (settings.minPlays > 0)
            {
                parameters.Add("minplays=" + settings.minPlays);
            }

            if (settings.minRating > 0)
            {
                parameters.Add("minrating=" + settings.minRating);
            }

            foreach (string arg in parameters)
            {
                sb.Append(arg);
            }

            XDocument result = XDocument.Load(sb.ToString());

            var collection = from coll in result.Descendants("item")
                             select new CollectionItem
                             {
                                 objecttype = coll.Attribute("objecttype").Value,
                                 objectID = int.Parse(coll.Attribute("objectid").Value),
                                 subType = coll.Attribute("subtype").Value,
                                 collID = int.Parse(coll.Attribute("collid").Value),
                                 name = coll.Element("name").Value,
                                 yearPublished = int.Parse(coll.Element("yearpublished").Value),
                                 image = coll.Element("image").Value,
                                 thumbnail = coll.Element("thumbnail").Value,

                                 minPlayers = int.Parse(coll.Element("stats").Attribute("minplayers").Value),
                                 maxPlayers = int.Parse(coll.Element("stats").Attribute("maxplayers").Value),
                                 numOwned = int.Parse(coll.Element("stats").Attribute("numowned").Value),

                                 userRated = int.Parse(coll.Element("stats").Element("rating").Element("usersrated").Attribute("value").Value),

                                 own = int.Parse(coll.Element("status").Attribute("own").Value),
                                 prevOwned = int.Parse(coll.Element("status").Attribute("prevowned").Value),
                                 forTrade = int.Parse(coll.Element("status").Attribute("fortrade").Value),
                                 want = int.Parse(coll.Element("status").Attribute("want").Value),
                                 wantToPlay = int.Parse(coll.Element("status").Attribute("wanttoplay").Value),
                                 wantToBuy = int.Parse(coll.Element("status").Attribute("wanttobuy").Value),
                                 wishlist = int.Parse(coll.Element("status").Attribute("wishlist").Value),
                                 preOrdered = int.Parse(coll.Element("status").Attribute("preordered").Value),
                                 numPlays = int.Parse(coll.Element("numplays").Value)
                             };

            return collection.ToList();
        }
    }
}
