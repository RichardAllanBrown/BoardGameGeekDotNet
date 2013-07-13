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
    /// Ensures the search XML is correctly parsed
    /// </summary>
    [TestClass]
    public class XMLParserTest_Search
    {
        public string testDataRelativePath = "TestData/Search.xml";

        [TestMethod]
        public void searchParse_NotExact_ID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseSearchXML(testData);

            // Assert
            Assert.AreEqual(1, result.Count(x => x.ObjectID == 143085));
        }

        [TestMethod]
        public void searchParse_NotExact_Name()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseSearchXML(testData);

            // Assert
            Assert.AreEqual("7 Dice Wonders", result.First(x => x.ObjectID == 143085).name);
        }

        [TestMethod]
        public void searchParse_NotExact_YearPublished()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseSearchXML(testData);

            // Assert
            Assert.AreEqual(2013, result.First(x => x.ObjectID == 143085).yearPublished);
        }
    }
}
