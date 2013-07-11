using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BGGdotNET.Client;
using BGGdotNET.Objects;
using BGGdotNET.Enums;

namespace BGGdotNET_Unit
{
    [TestClass]
    public class BoardGameXML
    {
        [TestMethod]
        public void boardgame_DefaultSettings_ReturnsSingleGame()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();
            
            // Act
            List<BoardGame> result = client.getBoardGame(103885);

            // Assert
            Assert.AreEqual(103885, result[0].ObjectID);
        }

        [TestMethod]
        public void boardgame_DefaultSettings_ReturnsManyGames()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();
            
            // Act
            List<BoardGame> result = client.getBoardGame(103885, 98778, 129622);

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void boardgame_WithReturnComments_ReturnsComments()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.fetch
            };

            // Act
            List<BoardGame> result = client.getBoardGame(settings, 98778);

            // Assert
            Assert.IsTrue(result[0].comments.Count > 0);
        }

        [TestMethod]
        public void boardgame_WithReturnCommentsSetOff_ReturnsNoComments()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();
            BoardGameSettings settings = new BoardGameSettings()
            {
                commSets = commentSettings.none
            };

            // Act
            List<BoardGame> result = client.getBoardGame(settings, 98778);

            // Assert
            Assert.IsTrue(result[0].comments.Count == 0);
        }

        [TestMethod]
        public void boardgame_WithReturnStats_StatsAreReturned()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();
            BoardGameSettings settings = new BoardGameSettings()
            {
                statSets = statsSettings.current
            };

            // Act
            List<BoardGame> result = client.getBoardGame(settings, 98778);

            // Assert
            Assert.IsTrue(result[0].statistics.Count > 0);
        }

        [TestMethod]
        public void boardgame_WithReturnHistory_HistoricStatsAreReturned()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();
            BoardGameSettings settings = new BoardGameSettings()
            {
                statSets = statsSettings.histroic,
                historicStatsFrom = new DateTime(2013, 01, 01),
                historicStatsTo = new DateTime(2013, 07, 01)
            };

            // Act
            List<BoardGame> result = client.getBoardGame(settings, 103885);

            // Assert
            Assert.IsTrue(result[0].statistics.Count > 1);
        }
    }
}
