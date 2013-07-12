using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BGGdotNET.Objects;
using BGGdotNET.Settings;
using BGGdotNET.Client;

namespace BGGdotNET_Test
{
    /// <summary>
    /// URLBuilderTest performs all unit testing on URLBuilder class, ensuring all url strings are returned as expected
    /// </summary>
    [TestClass]
    public class UrlBuilderTest
    {
        //Tests for the searchUrl builder method
        [TestMethod]
        public void searchURL_DefaultSettings_ReturnsUrl()
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
        public void searchURL_ExactSettings_ReturnsUrl()
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
        public void geekListURL_DefaultSettings_ReturnsUrl()
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
        public void geekListURL_WithCommentSettings_ReturnsUrl()
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
        public void boardGameURL_SingleGameNullSettings_ReturnsUrl()
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
        public void boardGameURL_MultipleGamesNullSettings_ReturnsUrl()
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
        public void boardGameURL_WithCommentsSettings_ReturnsUrl()
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
        public void boardGameURL_WithCurrentStatsSettings_ReturnsUrl()
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
        public void boardGameURL_WithHistoricStatsSettings_ReturnsUrl()
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
        public void boardGameURL_WithHistoricStatsButNoDates_ReturnsUrl()
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
        public void boardGameURL_WithHistoricStatsAndFromDate_ReturnsUrl()
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
        public void boardGameURL_WithHistoricStatsAndToDate_ReturnsUrl()
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

        //Tests for the usercollection builder method on the userCollection enum setting
        [TestMethod]
        public void userCollectionURL_DefaultSetting_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho";

            // Act
            string result = testBuilder.buildUserCollectionUrl(null, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_Own_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.own
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?own=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_Rated_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.rated
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?rated=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_Played_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.played
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?played=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_Comment_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.comment
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?comment=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_Trade_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.trade
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?trade=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_Want_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.want
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?want=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_WishList_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.wishlist
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?wishlist=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_WantToPlay_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.wantToPlay
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?wanttoplay=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_WantToBuy_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.wantToBuy
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?wanttobuy=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_PreOwned_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.preOwned
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?prevowned=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_PreOredered_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.preOrdered
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?preordered=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_HasParts_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.hasParts
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?hasparts=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_WantsParts_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.wantParts
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?wantparts=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_NotifyContent_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.notifyContent
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?notifycontent=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_NotifySale_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.notifySale
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?notifysale=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_NotifyAuction_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.notifyAuction
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?notifyauction=1";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_WishListPriority_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.wishlistPriority,
                wishListPriority = 3
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?wishlistpriority=3";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        //Tests for the usercollection builder method on the rating/plays settings
        [TestMethod]
        public void userCollectionURL_MaxBGGRating_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all,
                maxBGGRating = 8
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?maxbggrating=8";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_MinBGGRating_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all,
                minBGGRating = 3
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?minbggrating=3";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_MaxRating_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all,
                maxRating = 4
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?maxrating=4";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_MinRating_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all,
                minRating = 7
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?minrating=7";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_MinPlays_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all,
                minPlays = 35
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?minplays=35";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_MaxPlays_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.all,
                maxPlays = 95
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?maxplays=95";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        //Tests for the userCollection builder method using multiple settings
        [TestMethod]
        public void userCollectionURL_2Settings_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.own,
                minPlays = 12
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?own=1&minplays=12";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void userCollectionURL_7Settings_ReturnsUrl()
        {
            // Arrange
            IUrlBuilder testBuilder = new UrlBuilder();
            CollectionSettings set = new CollectionSettings()
            {
                collectionFilter = userCollection.own,
                minPlays = 12,
                maxPlays = 98,
                minBGGRating = 3,
                maxBGGRating = 9,
                minRating = 2,
                maxRating = 10
            };

            string expected = "http://www.boardgamegeek.com/xmlapi/collection/Rokusho?own=1&maxbggrating=9&maxplays=98&maxrating=10&minbggrating=3&minplays=12&minrating=2";

            // Act
            string result = testBuilder.buildUserCollectionUrl(set, "Rokusho");

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
