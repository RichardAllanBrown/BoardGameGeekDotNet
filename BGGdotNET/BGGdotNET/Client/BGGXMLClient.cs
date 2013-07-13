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
        private IUrlBuilder builder = new UrlBuilder();
        private IXMLParser parser = new XMLParser();

        public List<BoardGame> getBoardGame(params int[] gameIDs)
        {
            return getBoardGame(null, gameIDs);
        }

        public List<BoardGame> getBoardGame(BoardGameSettings settings, params int[] gameIDs)
        {
            string requestUrl = builder.buildBoardGameUrl(settings, gameIDs);

            XDocument result = XDocument.Load(requestUrl);

            return parser.parseBoardGameXML(result);
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

            return parser.parseSearchXML(result);
        }

        public GeekList getGeekList(int listID)
        {
            return getGeekList(commentSettings.none, listID);
        }

        public GeekList getGeekList(commentSettings settings, int listID)
        {
            string requestUrl = builder.buildGeekListUrl(settings, listID);

            XDocument result = XDocument.Load(requestUrl);

            return parser.parseGeekListXML(result);
        }

        public List<CollectionItem> getUserCollection(string username)
        {
            return getUserCollection(null, username);
        }

        public List<CollectionItem> getUserCollection(CollectionSettings settings, string username)
        {
            string requestUrl = builder.buildUserCollectionUrl(settings, username);

            XDocument result = XDocument.Load(requestUrl);

            return parser.parseCollectionXML(result);
        }
    }
}
