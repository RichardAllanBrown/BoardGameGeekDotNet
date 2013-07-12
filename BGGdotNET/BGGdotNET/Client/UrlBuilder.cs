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
            throw new NotImplementedException();
        }
    }
}
