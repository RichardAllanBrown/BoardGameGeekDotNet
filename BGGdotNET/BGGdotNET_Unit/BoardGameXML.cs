using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BGGdotNET.Client;
using BGGdotNET.Objects;

namespace BGGdotNET_Unit
{
    [TestClass]
    public class BoardGameXML
    {
        [TestMethod]
        public void boardgame_DefaultSettings_ReturnsSingleGame()
        {
            IBGGClient client = new BGGXMLClient();
            List<BoardGame> result = client.getBoardGame(103885);

            Assert.AreEqual(103885, result[0].ObjectID);
        }

        [TestMethod]
        public void boardgame_DefaultSettings_ReturnsManyGames()
        {
            IBGGClient client = new BGGXMLClient();
            List<BoardGame> result = client.getBoardGame(103885, 98778, 129622);

            Assert.AreEqual(3, result.Count);
        }
    }
}
