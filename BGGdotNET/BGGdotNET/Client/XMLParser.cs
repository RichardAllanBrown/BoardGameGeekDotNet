using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using BGGdotNET.Objects;

namespace BGGdotNET.Client
{
    public class XMLParser : IXMLParser
    {
        public List<BoardGame> parseBoardGameXML(XDocument input)
        {
            var boardgames = from data in input.Descendants("boardgame")
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
                                                 username = com.Attribute("username").Value,
                                                 comment = com.Value,
                                                 //rating = (float)com.Attribute("rating")
                                             }).ToList(),

                                 statistics = (from stat in data.Element("statistics").Elements("ratings")
                                               select new BoardGameStats
                                               {
                                                   statDate = DateTime.ParseExact(stat.Attribute("date").Value,"yyyyMMdd", null),
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
                                                   ranks = (from ranks in stat.Elements("ranks").Elements("rank")
                                                            select new BoardGameRank
                                                            {
                                                                id = (int)ranks.Attribute("id"),
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
                                                                 voteCount = (int)res.Attribute("numvotes")
                                                             }).ToList()
                                          }).ToList()
                             };

            return boardgames.ToList();
        }

        public List<BGSearchResult> parseSearchXML(XDocument input)
        {
            var searchResults = from data in input.Descendants("boardgame")
                                select new BGSearchResult
                                {
                                    name = data.Element("name").Value,
                                    yearPublished = int.Parse(data.Element("yearpublished").Value),
                                    ObjectID = (int)data.Attribute("objectid")
                                };

            return searchResults.ToList();
        }

        public List<CollectionItem> parseCollectionXML(XDocument input)
        {
            var collection = from coll in input.Descendants("item")
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

        public GeekList parseGeekListXML(XDocument input)
        {
            var geekListResult = from data in input.Descendants("geeklist")
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
                                     editDate = ParseUtils.stringToDateTime(data.Element("editdate").Value),
                                     postDate = ParseUtils.stringToDateTime(data.Element("postdate").Value),

                                     comments = (from com in data.Descendants("comment")
                                                 select new GeekListComment
                                                 {
                                                     username = com.Attribute("username").Value,
                                                     thumbs = int.Parse(com.Attribute("thumbs").Value),
                                                     commentText = com.Value,
                                                     editDate = ParseUtils.stringToDateTime(com.Attribute("editdate").Value),
                                                     postDate = ParseUtils.stringToDateTime(com.Attribute("postdate").Value),
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
                                                  body = it.Element("body").Value, //added
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
    }
}
