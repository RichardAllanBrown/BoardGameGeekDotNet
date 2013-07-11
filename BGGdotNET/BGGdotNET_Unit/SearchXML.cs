using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BGGdotNET.Client;
using BGGdotNET.Enums;

namespace BGGdotNET_Unit
{
    [TestClass]
    public class SearchXML
    {
        [TestMethod]
        public void search_WithDefaultSettings_ReturnsAGameWithRightNames()
        {
            IBGGClient client = new BGGXMLClient();
            var result = client.searchBoardGame("7 Wonders");

            Assert.IsTrue(result.Any(x => x.name == "7 Wonders"));
        }

        [TestMethod]
        public void search_WithDefaultSettings_ReturnsManyGamesWithRightNames()
        {
            IBGGClient client = new BGGXMLClient();
            var result = client.searchBoardGame("7 Wonders");

            Assert.IsTrue(1 < result.Count(x => x.name.Contains("7 Wonders")));
        }

        [TestMethod]
        public void search_WithExact_ReturnsCorrectGame()
        {
            IBGGClient client = new BGGXMLClient();
            var result = client.searchBoardGame(searchSettings.exact, "7 Wonders");

            Assert.IsTrue(result.Any(x => x.name == "7 Wonders"));
        }

        [TestMethod]
        public void search_WithExact_ReturnsOneGame()
        {
            IBGGClient client = new BGGXMLClient();
            var result = client.searchBoardGame(searchSettings.exact, "7 Wonders");

            Assert.AreEqual(1, result.Count);
        }
    }
}
