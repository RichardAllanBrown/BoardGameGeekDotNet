using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BGGdotNET.Objects;
using BGGdotNET.Settings;
using BGGdotNET.Client;

namespace BGGdotNET_Unit
{
    /// <summary>
    /// Summary description for UrlBuilderTest
    /// </summary>
    [TestClass]
    public class UrlBuilderTest
    {
        //Tests for the searchUrl builder method
        [TestMethod]
        public void searchURL_DefaultSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            string expected = "http://www.boardgamegeek.com/xmlapi/search?search=7 Wonders";

            // Act
            string result = testBuilder.buildSearchUrl(SearchSettings.notExact, "7 Wonders");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void searchURL_ExactSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            string expected = "http://www.boardgamegeek.com/xmlapi/search?search=7 Wonders&exact=1";

            // Act
            string result = testBuilder.buildSearchUrl(SearchSettings.exact, "7 Wonders");

            // Assert
            Assert.AreEqual(expected, result);
        }

        //Tests for the geeklisturl builder method
        [TestMethod]
        public void geekListURL_DefaultSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            string expected = "http://www.boardgamegeek.com/xmlapi/geeklist/12345";

            // Act
            string result = testBuilder.buildGeekListUrl(commentSettings.none, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void geekListURL_WithCommentSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            string expected = "http://www.boardgamegeek.com/xmlapi/geeklist/12345?comments=1";

            // Act
            string result = testBuilder.buildGeekListUrl(commentSettings.fetch, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        //Tests for the boardgameurl builder method
        [TestMethod]
        public void boardGameURL_SingleGameNullSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345";

            // Act
            string result = testBuilder.buildBoardGameUrl(null, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_MultipleGamesNullSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345,11111,22222,33333";

            // Act
            string result = testBuilder.buildBoardGameUrl(null, 12345, 11111, 22222, 33333);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_WithCommentsSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.fetch,
                statSets = statsSettings.none
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345?comments=1";
            
            // Act
            string result = testBuilder.buildBoardGameUrl(settings, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_WithCurrentStatsSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.none,
                statSets = statsSettings.current
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345?comments=0&stats=1";

            // Act
            string result = testBuilder.buildBoardGameUrl(settings, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_WithHistoricStatsSettings_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.none,
                statSets = statsSettings.histroic,
                historicStatsFrom = new DateTime(2012, 01, 21),
                historicStatsTo = new DateTime(2013, 02, 26)
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345?comments=0&historical=1&from=2012-01-21&to=2013-02-26";

            // Act
            string result = testBuilder.buildBoardGameUrl(settings, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_WithHistoricStatsButNoDates_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.none,
                statSets = statsSettings.histroic
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345?comments=0&historical=1";

            // Act
            string result = testBuilder.buildBoardGameUrl(settings, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_WithHistoricStatsAndFromDate_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.none,
                statSets = statsSettings.histroic,
                historicStatsFrom = new DateTime(2011, 01, 02)
            };

            string toDate = DateTime.Now.ToString("yyyy-MM-dd");

            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345?comments=0&historical=1&from=2011-01-02&to=" + toDate;

            // Act
            string result = testBuilder.buildBoardGameUrl(settings, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void boardGameURL_WithHistoricStatsAndToDate_ReturnsCorrectUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.none,
                statSets = statsSettings.histroic,
                historicStatsTo = new DateTime(2013, 01, 02)
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/boardgame/12345?comments=0&historical=1&from=2006-03-18&to=2013-01-02";

            // Act
            string result = testBuilder.buildBoardGameUrl(settings, 12345);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
