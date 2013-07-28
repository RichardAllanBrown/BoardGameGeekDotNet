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
                                 age = (int?) data.Element("age") ?? 0,
                                 description = (string) data.Element("description") ?? "",
                                 imageThumnailURL = (string) data.Element("thumbnail") ?? "",
                                 imageURL = (string) data.Element("image") ?? "",
                                 maxPlayers = (int?) data.Element("maxplayers") ?? 0,
                                 minPlayers = (int?) data.Element("minplayers") ?? 0,
                                 ObjectID = (int?) data.Attribute("objectid") ?? 0,
                                 yearPublished = (int?) data.Element("yearpublished") ?? 0,
                                 playingTime = (int?) data.Element("playingtime") ?? 0,

                                 categories = (from cat in data.Elements("boardgamecategory")
                                               select new BoardGameGeekPair
                                               {
                                                   value = (string) cat ?? "",
                                                   objectID = (int?) cat.Attribute("objectid") ?? 0
                                               }).ToList(),

                                 designers = (from des in data.Elements("boardgamedesigner")
                                              select new BoardGameGeekPair
                                              {
                                                  value = (string) des ?? "",
                                                  objectID = (int?) des.Attribute("objectid") ?? 0
                                              }).ToList(),

                                 expansions = (from exp in data.Elements("boardgameexpansion")
                                               select new BoardGameGeekPair
                                               {
                                                   value = (string) exp ?? "",
                                                   objectID = (int?) exp.Attribute("objectid") ?? 0
                                               }).ToList(),

                                 honors = (from hon in data.Elements("boardgamehonor")
                                           select new BoardGameGeekPair
                                           {
                                               value = (string) hon ?? "",
                                               objectID = (int?) hon.Attribute("objectid") ?? 0
                                           }).ToList(),

                                 mechanics = (from mec in data.Elements("boardgamemechanic")
                                              select new BoardGameGeekPair
                                              {
                                                  value = (string) mec ?? "",
                                                  objectID = (int?) mec.Attribute("objectid") ?? 0
                                              }).ToList(),

                                 names = (from name in data.Elements("name")
                                          select new BoardGameName
                                          {
                                              name = (string) name ?? "",
                                              sortIndex = (int?) name.Attribute("sortindex") ?? 0,
                                              isPrimary = (bool?) name.Attribute("primary") ?? false
                                          }).ToList(),

                                 podcasts = (from pod in data.Elements("boardgamepodcastepisode")
                                             select new BoardGameGeekPair
                                             {
                                                 value = (string) pod ?? "",
                                                 objectID = (int?) pod.Attribute("objectid") ?? 0
                                             }).ToList(),

                                 publishers = (from pub in data.Elements("boardgamepublisher")
                                               select new BoardGameGeekPair
                                               {
                                                   value = (string) pub ?? "",
                                                   objectID = (int?) pub.Attribute("objectid") ?? 0
                                               }).ToList(),

                                 subdomains = (from sub in data.Elements("boardgamesubdomain")
                                               select new BoardGameGeekPair
                                               {
                                                   value = (string) sub ?? "",
                                                   objectID = (int?) sub.Attribute("objectid") ?? 0
                                               }).ToList(),

                                 versions = (from ver in data.Elements("boardgameversion")
                                             select new BoardGameGeekPair
                                             {
                                                 value = (string) ver ?? "",
                                                 objectID = (int?) ver.Attribute("objectid") ?? 0
                                             }).ToList(),

                                 comments = (from com in data.Elements("comment")
                                             select new BoardGameComment
                                             {
                                                 username = (string) com.Attribute("username") ?? "",
                                                 comment = (string) com ?? "",
                                                 rating = (float?) com.Attribute("rating") ?? 0
                                             }).ToList(),

                                 statistics = (from stat in data.Element("statistics").Elements("ratings")
                                               select new BoardGameStats
                                               {
                                                   statDate = (DateTime?) DateTime.ParseExact((string) stat.Attribute("date") ?? "00010101", "yyyyMMdd", null) ?? DateTime.MinValue,
                                                   average = (float?) stat.Element("average") ?? 0,
                                                   averageWeight = (float?) stat.Element("averageweight") ?? 0,
                                                   bayesAverage = (float?) stat.Element("bayesaverage") ?? 0,
                                                   median = (float?) stat.Element("median") ?? 0,
                                                   numComments = (int?) stat.Element("numcomments") ?? 0,
                                                   numWeights = (int?) stat.Element("numweights") ?? 0,
                                                   owned = (int?) stat.Element("owned") ?? 0,
                                                   trading = (int?) stat.Element("trading") ?? 0,
                                                   standardDeviation = (float?) stat.Element("stddev") ?? 0,
                                                   usersRated = (int?) stat.Element("usersrated") ?? 0,
                                                   wanting = (int?) stat.Element("wanting") ?? 0,
                                                   wishing = (int?) stat.Element("wishing") ?? 0,
                                                   ranks = (from ranks in stat.Elements("ranks").Elements("rank")
                                                            select new BoardGameRank
                                                            {
                                                                id = (int?) ranks.Attribute("id") ?? 0,
                                                                name = (string) ranks.Attribute("name") ?? "",
                                                                friendlyName = (string) ranks.Attribute("friendlyname") ?? "",
                                                                type = (string) ranks.Attribute("type") ?? "",
                                                                value = (int?) ranks.Attribute("value") ?? 0,
                                                                bayesAverage = (float?) ranks.Attribute("bayesaverage") ?? 0
                                                            }).ToList()
                                               }).ToList(),

                                 polls = (from pol in data.Elements("poll")
                                          select new BoardGamePoll
                                          {
                                              pollName = (string) pol.Attribute("name") ?? "",
                                              pollTitle = (string) pol.Attribute("title") ?? "",
                                              totalVotes = (int?) pol.Attribute("totalvotes") ?? 0,
                                              resultsList = (from res in pol.Elements("results").Elements("result")
                                                             select new BoardGamePollResult
                                                             {
                                                                 responseValue = (string) res.Attribute("value") ?? "",
                                                                 voteCount = (int?) res.Attribute("numvotes") ?? 0,
                                                                 level = (int?) res.Attribute("level") ?? 0
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
                                    name = (string) data.Element("name") ?? "",
                                    yearPublished = (int?) data.Element("yearpublished") ?? 0,
                                    ObjectID = (int?) data.Attribute("objectid") ?? 0
                                };

            return searchResults.ToList();
        }

        public List<CollectionItem> parseCollectionXML(XDocument input)
        {
            var collection = from coll in input.Descendants("item")
                             select new CollectionItem
                             {
                                 objecttype = (string) coll.Attribute("objecttype") ?? "",
                                 objectID = (int?) coll.Attribute("objectid") ?? 0,
                                 subType = (string) coll.Attribute("subtype") ?? "",
                                 collID = (int?) coll.Attribute("collid") ?? 0,
                                 name = (string) coll.Element("name") ?? "",
                                 yearPublished = (int?) coll.Element("yearpublished") ?? 0,
                                 image = (string) coll.Element("image") ?? "",
                                 thumbnail = (string) coll.Element("thumbnail") ?? "",

                                 minPlayers = (int?) coll.Element("stats").Attribute("minplayers") ?? 0,
                                 maxPlayers = (int?) coll.Element("stats").Attribute("maxplayers") ?? 0,
                                 numOwned = (int?) coll.Element("stats").Attribute("numowned") ?? 0,

                                 userRated = (int?) coll.Element("stats").Element("rating").Element("usersrated").Attribute("value") ?? 0,

                                 own = (int?) coll.Element("status").Attribute("own") ?? 0,
                                 prevOwned = (int?) coll.Element("status").Attribute("prevowned") ?? 0,
                                 forTrade = (int?) coll.Element("status").Attribute("fortrade") ?? 0,
                                 want = (int?) coll.Element("status").Attribute("want") ?? 0,
                                 wantToPlay = (int?) coll.Element("status").Attribute("wanttoplay") ?? 0,
                                 wantToBuy = (int?) coll.Element("status").Attribute("wanttobuy") ?? 0,
                                 wishlist = (int?) coll.Element("status").Attribute("wishlist") ?? 0,
                                 preOrdered = (int?) coll.Element("status").Attribute("preordered") ?? 0,
                                 numPlays = (int?) coll.Element("numplays") ?? 0
                             };

            return collection.ToList();
        }

        public GeekList parseGeekListXML(XDocument input)
        {
            var geekListResult = from data in input.Descendants("geeklist")
                                 select new GeekList
                                 {
                                     description = (string) data.Element("description") ?? "",
                                     id = (int?) data.Attribute("id") ?? 0,
                                     numItems = (int?) data.Element("numitems") ?? 0,
                                     editDateTimestamp = (string) data.Element("editdate_timestamp") ?? "",
                                     postDateTimestamp = (string) data.Element("postdate_timestamp") ?? "",
                                     thumbs = (int?) data.Element("thumbs") ?? 0,
                                     title = (string) data.Element("title") ?? "",
                                     userName = (string) data.Element("username") ?? "",
                                     editDate = ParseUtils.stringToDateTime((string) data.Element("editdate") ?? ""),
                                     postDate = ParseUtils.stringToDateTime((string) data.Element("postdate") ?? ""),

                                     comments = (from com in data.Elements("comment")
                                                 select new GeekListComment
                                                 {
                                                     username = (string) com.Attribute("username") ?? "",
                                                     thumbs = (int?) com.Attribute("thumbs") ?? 0,
                                                     commentText = (string) com ?? "",
                                                     editDate = ParseUtils.stringToDateTime((string) com.Attribute("editdate") ?? ""),
                                                     postDate = ParseUtils.stringToDateTime((string) com.Attribute("postdate") ?? ""),
                                                 }).ToList(),

                                     items = (from it in data.Descendants("item")
                                              select new GeekListItem
                                              {
                                                  id = (int?) it.Attribute("id") ?? 0,
                                                  objectType = (string) it.Attribute("objecttype") ?? "",
                                                  subType = (string) it.Attribute("subtype") ?? "",
                                                  objectID = (int?) it.Attribute("objectid") ?? 0,
                                                  objectName = (string) it.Attribute("objectname") ?? "",
                                                  userName = (string) it.Attribute("username") ?? "",
                                                  thumbs = (int?) it.Attribute("thumbs") ?? 0,
                                                  imageID = (int?) it.Attribute("imageid") ?? 0,
                                                  body = (string) it.Element("body") ?? "",
                                                  editDate = ParseUtils.stringToDateTime((string) it.Attribute("editdate") ?? ""),
                                                  postDate = ParseUtils.stringToDateTime((string) it.Attribute("postdate") ?? ""),
                                                  comments = (from com in it.Elements("comment")
                                                              select new GeekListComment
                                                              {
                                                                  username = (string) com.Attribute("username") ?? "",
                                                                  thumbs = (int?) com.Attribute("thumbs") ?? 0,
                                                                  commentText = (string) com ?? "",
                                                                  editDate = ParseUtils.stringToDateTime((string) com.Attribute("editdate") ?? ""),
                                                                  postDate = ParseUtils.stringToDateTime((string) com.Attribute("postdate") ?? "")
                                                              }).ToList()
                                              }).ToList()
                                 };

            return geekListResult.FirstOrDefault();
        }
    }
}
