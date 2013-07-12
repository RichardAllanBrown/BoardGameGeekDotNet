using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGdotNET.Settings;

namespace BGGdotNET.Client
{
    public class UrlBuilder : IUrlBuilder
    {
        private string url = "http://www.boardgamegeek.com/xmlapi";

        public string buildBoardGameUrl(Settings.BoardGameSettings settings, params int[] gameIDs)
        {
            StringBuilder sb = new StringBuilder(url);

            sb.Append("/boardgame/");

            foreach (int parm in gameIDs)
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

                if (settings.statSets == statsSettings.current)
                {
                    sb.Append("&stats=1");
                }
                else if (settings.statSets == statsSettings.histroic)
                {
                    sb.Append("&historical=1");

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
            }

            return sb.ToString();
        }

        public string buildSearchUrl(Settings.SearchSettings settings, string searchInput)
        {
            string requestUrl = url + "/search?search=" + searchInput;

            //The exact argument will only return a single search result
            if (settings == SearchSettings.exact)
            {
                requestUrl = requestUrl + "&exact=1";
            }

            return requestUrl;
        }

        public string buildGeekListUrl(Settings.commentSettings settings, int listID)
        {
            string requestUrl = url + "/geeklist/" + listID;

            if (settings == commentSettings.fetch)
            {
                requestUrl = requestUrl + "?comments=1";
            }

            return requestUrl;
        }

        public string buildUserCollectionUrl(Settings.CollectionSettings settings, string username)
        {
            StringBuilder sb = new StringBuilder(url);

            sb.Append("/collection/");
            sb.Append(username);

            if (settings != null)
            {
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
                        parameters.Add("played=1");
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

                if (parameters.Count > 0)
                {
                    sb.Append("?");
                }

                foreach (string arg in parameters)
                {
                    sb.Append(arg);

                    if (parameters.Count >= 2 && arg != parameters[parameters.Count - 1])
                    {
                        sb.Append("&");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
