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

        //Methods that test the values of a boardgame is correctly parsed.

        [TestMethod]
        public void boardGameParse_SingleGameAllData_ObjectID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.Count(x => x.ObjectID == 124742));
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_YearPublished()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(2012, result.First(x => x.ObjectID == 124742).yearPublished);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_MinPlayers()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(2, result.First(x => x.ObjectID == 124742).minPlayers);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_MaxPlayers()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(4, result.First(x => x.ObjectID == 124742).maxPlayers);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_PlayingTime()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(45, result.First(x => x.ObjectID == 124742).playingTime);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Age()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(14, result.First(x => x.ObjectID == 124742).age);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Description()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "A shorter simpler description that is testable.  Duh.";

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(expected, result.First(x => x.ObjectID == 124742).description);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_ThumbnailURL()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "http://cf.geekdo-images.com/images/pic1324609_t.jpg";

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(expected, result.First(x => x.ObjectID == 124742).imageThumnailURL);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_ImageURL()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "http://cf.geekdo-images.com/images/pic1324609.jpg";

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(expected, result.First(x => x.ObjectID == 124742).imageURL);
        }

        //Methods that test the names of BoardGames

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Names_AllNamesParsed()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(2, result.First(x => x.ObjectID == 124742).names.Count);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Names_AllNamesExist()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.First(x => x.ObjectID == 124742).names.Count(x => x.name == "Android: Netrunner"));
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Names_SortIndex()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.First(x => x.ObjectID == 124742).names.First(x => x.name == "Android: Netrunner").sortIndex);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Names_FetchPrimary()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual("Android: Netrunner", result.First(x => x.ObjectID == 124742).getPrimaryName());
        }

        //Methods to test all BGGPairings are returned

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Honors()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(5, result.First(x => x.ObjectID == 124742).honors.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Honors_ObjectID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.First(x => x.ObjectID == 124742).honors.Count(x => x.objectID == 20116));
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Honors_Value()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "2012 Golden Geek Best 2-Player Board Game Nominee";

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(expected, result.First(x => x.ObjectID == 124742).honors.First(x => x.objectID == 20116).value);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Expansions()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(10, result.First(x => x.ObjectID == 124742).expansions.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Categories()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(3, result.First(x => x.ObjectID == 124742).categories.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Publishers()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(5, result.First(x => x.ObjectID == 124742).publishers.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Designers()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(2, result.First(x => x.ObjectID == 124742).designers.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Podcasts()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(17, result.First(x => x.ObjectID == 124742).podcasts.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Mechanics()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(3, result.First(x => x.ObjectID == 124742).mechanics.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_SubDomains()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(2, result.First(x => x.ObjectID == 124742).subdomains.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Versions()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(5, result.First(x => x.ObjectID == 124742).versions.Count());
        }

        //Methods to test the polls objects within a boardgame

        [TestMethod]
        public void boardGameParse_SingleGameAllData_PollsCount()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(3, result.First(x => x.ObjectID == 124742).polls.Count());
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_Name()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.First(x => x.ObjectID == 124742).polls.Count(x => x.pollName == "language_dependence"));
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_Title()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "Language Dependence";

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(expected, result.First(x => x.ObjectID == 124742).polls.First(x => x.pollName == "language_dependence").pollTitle);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_TotalVotes()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(90, result.First(x => x.ObjectID == 124742).polls.First(x => x.pollName == "language_dependence").totalVotes);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_ResponseCount()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(5, result.First(x => x.ObjectID == 124742).polls.First(x => x.pollName == "language_dependence").resultsList.Count);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_Response_Level()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(1, result.First(x => x.ObjectID == 124742)
                                    .polls.First(x => x.pollName == "language_dependence")
                                    .resultsList.Count(x => x.level == 1));
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_Response_Value()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual("No necessary in-game text", result.First(x => x.ObjectID == 124742)
                                    .polls.First(x => x.pollName == "language_dependence")
                                    .resultsList.First(x => x.level == 1).responseValue);
        }

        [TestMethod]
        public void boardGameParse_SingleGameAllData_Polls_Response_VoteCount()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseBoardGameXML(testData);

            // Assert
            Assert.AreEqual(4, result.First(x => x.ObjectID == 124742)
                                    .polls.First(x => x.pollName == "language_dependence")
                                    .resultsList.First(x => x.level == 1).voteCount);
        }

        //Methods to test the comments objects within a boardgame


    }
}
