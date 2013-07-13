using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;

using BGGdotNET.Client;
using BGGdotNET.Objects;

namespace BGGdotNET_Test.UnitTest
{
    /// <summary>
    /// Ensures the boardgame XML is correctly parsed
    /// </summary>
    [TestClass]
    public class XMLParserTest_BoardGame
    {
        public string testDataRelativePath = "TestData/BoardGame.xml";

        [TestMethod]
        public void boardGameParse_SingleGameAllData_objectID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.Count(x => x.ObjectID == 124742));
        }
    }
}
