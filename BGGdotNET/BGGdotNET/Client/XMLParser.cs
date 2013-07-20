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
            var boardgames = (from data in input.Descendants("boardgame")
                             select new BoardGame
                             {
                                 age = ParseUtils.stringToInt(data.Element("age").Value),
                                 description = data.Element("description").Value ?? "",
                                 imageThumnailURL = data.Element("thumbnail").Value ?? "",
                                 imageURL = data.Element("image").Value ?? "",
                                 maxPlayers = ParseUtils.stringToInt(data.Element("maxplayers").Value),
                                 minPlayers = ParseUtils.stringToInt(data.Element("minplayers").Value),
                                 ObjectID = ParseUtils.stringToInt(data.Attribute("objectid").Value),
                                 yearPublished = ParseUtils.stringToInt(data.Element("yearpublished").Value),
                                 playingTime = ParseUtils.stringToInt(data.Element("playingtime").Value),

                                 categories = (from cat in data.Elements("boardgamecategory")
                                               select new BoardGameGeekPair
                                               {
                                                   value = cat.Value ?? "",
                                                   objectID = ParseUtils.stringToInt(cat.Attribute("objectid").Value)
                                               }).ToList(),

                                 designers = (from des in data.Elements("boardgamedesigner")
                                              select new BoardGameGeekPair
                                              {
                                                  value = des.Value ?? "",
                                                  objectID = ParseUtils.stringToInt(des.Attribute("objectid").Value)
                                              }).ToList(),

                                 expansions = (from exp in data.Elements("boardgameexpansion")
                                               select new BoardGameGeekPair
                                               {
                                                   value = exp.Value ?? "",
                                                   objectID = ParseUtils.stringToInt(exp.Attribute("objectid").Value)
                                               }).ToList(),

                                 honors = (from hon in data.Elements("boardgamehonor")
                                           select new BoardGameGeekPair
                                           {
                                               value = hon.Value ?? "",
                                               objectID = ParseUtils.stringToInt(hon.Attribute("objectid").Value)
                                           }).ToList(),

                                 mechanics = (from mec in data.Elements("boardgamemechanic")
                                              select new BoardGameGeekPair
                                              {
                                                  value = mec.Value ?? "",
                                                  objectID = ParseUtils.stringToInt(mec.Attribute("objectid").Value)
                                              }).ToList(),

                                 names = (from name in data.Elements("name")
                                          select new BoardGameName
                                          {
                                              name = name.Value,
                                              sortIndex = ParseUtils.stringToInt(name.Attribute("sortindex").Value),
                                              isPrimary = (bool?)name.Attribute("primary") ?? false
                                          }).ToList(),

                                 podcasts = (from pod in data.Elements("boardgamepodcastepisode")
                                             select new BoardGameGeekPair
                                             {
                                                 value = pod.Value ?? "",
                                                 objectID = ParseUtils.stringToInt(pod.Attribute("objectid").Value)
                                             }).ToList(),

                                 publishers = (from pub in data.Elements("boardgamepublisher")
                                               select new BoardGameGeekPair
                                               {
                                                   value = pub.Value ?? "",
                                                   objectID = ParseUtils.stringToInt(pub.Attribute("objectid").Value)
                                               }).ToList(),

                                 subdomains = (from sub in data.Elements("boardgamesubdomain")
                                               select new BoardGameGeekPair
                                               {
                                                   value = sub.Value ?? "",
                                                   objectID = ParseUtils.stringToInt(sub.Attribute("objectid").Value)
                                               }).ToList(),

                                 versions = (from ver in data.Elements("boardgameversion")
                                             select new BoardGameGeekPair
                                             {
                                                 value = ver.Value ?? "",
                                                 objectID = ParseUtils.stringToInt(ver.Attribute("objectid").Value)
                                             }).ToList(),

                                 comments = (from com in data.Elements("comment")
                                             select new BoardGameComment
                                             {
                                                 username = com.Attribute("username").Value,
                                                 comment = com.Value ?? "",
                                                 rating = ParseUtils.setingToFloat(com.Attribute("rating").Value)
                                             }).ToList(),

                                 statistics = (from stat in data.Element("statistics").Elements("ratings")
                                               select new BoardGameStats
                                               {
                                                   statDate = DateTime.ParseExact(stat.Attribute("date").Value, "yyyyMMdd", null),
                                                   average = ParseUtils.setingToFloat(stat.Element("average").Value),
                                                   averageWeight = ParseUtils.setingToFloat(stat.Element("averageweight").Value),
                                                   bayesAverage = ParseUtils.setingToFloat(stat.Element("bayesaverage").Value),
                                                   median = ParseUtils.setingToFloat(stat.Element("median").Value),
                                                   numComments = ParseUtils.stringToInt(stat.Element("numcomments").Value),
                                                   numWeights = ParseUtils.stringToInt(stat.Element("numweights").Value),
                                                   owned = ParseUtils.stringToInt(stat.Element("owned").Value),
                                                   trading = ParseUtils.stringToInt(stat.Element("trading").Value),
                                                   standardDeviation = ParseUtils.setingToFloat(stat.Element("stddev").Value),
                                                   usersRated = ParseUtils.stringToInt(stat.Element("usersrated").Value),
                                                   wanting = ParseUtils.stringToInt(stat.Element("wanting").Value),
                                                   wishing = ParseUtils.stringToInt(stat.Element("wishing").Value),
                                                   ranks = (from ranks in stat.Elements("ranks").Elements("rank")
                                                            select new BoardGameRank
                                                            {
                                                                id = ParseUtils.stringToInt(ranks.Attribute("id").Value),
                                                                name = ranks.Attribute("name").Value ?? "",
                                                                friendlyName = ranks.Attribute("friendlyname").Value,
                                                                type = ranks.Attribute("type").Value ?? "",
                                                                value = ParseUtils.stringToInt(ranks.Attribute("value").Value),
                                                                bayesAverage = ParseUtils.setingToFloat(ranks.Attribute("bayesaverage").Value)
                                                            }).ToList()
                                               }).ToList(),

                                 polls = (from pol in data.Elements("poll")
                                          select new BoardGamePoll
                                          {
                                              pollName = pol.Attribute("name").Value ?? "",
                                              pollTitle = pol.Attribute("title").Value ?? "",
                                              totalVotes = ParseUtils.stringToInt(pol.Attribute("totalvotes").Value),
                                              resultsList = (from res in pol.Elements("results").Elements("result")
                                                             select new BoardGamePollResult
                                                             {
                                                                 responseValue = res.Attribute("value").Value ?? "",
                                                                 voteCount = (int?)res.Attribute("numvotes") ?? 0,
                                                                 level = (int?)res.Attribute("level") ?? 0
                                                             }).ToList()
                                          }).ToList()
                             });

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

                                     comments = (from com in data.Elements("comment")
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
                                                  body = it.Element("body").Value,
                                                  editDate = ParseUtils.stringToDateTime(it.Attribute("editdate").Value),
                                                  postDate = ParseUtils.stringToDateTime(it.Attribute("postdate").Value),
                                                  comments = (from com in it.Elements("comment")
                                                              select new GeekListComment
                                                              {
                                                                  username = com.Attribute("username").Value,
                                                                  thumbs = int.Parse(com.Attribute("thumbs").Value),
                                                                  commentText = com.Value,
                                                                  editDate = ParseUtils.stringToDateTime(com.Attribute("editdate").Value),
                                                                  postDate = ParseUtils.stringToDateTime(com.Attribute("postdate").Value)
                                                              }).ToList()
                                              }).ToList()
                                 };

            return geekListResult.FirstOrDefault();
        }
    }
}
