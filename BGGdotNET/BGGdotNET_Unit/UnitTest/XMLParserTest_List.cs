using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

using BGGdotNET.Client;
using BGGdotNET.Objects;

namespace BGGdotNET_Test.UnitTest
{
    /// <summary>
    /// XMLParserTest uses test data generated from the BGG API to ensure objects are correctly built
    /// </summary>
    [TestClass]
    public class XMLParserTest_List
    {
        public string testDataRelativePath = "TestData/GeekList.xml";

        [TestMethod]
        public void geekListParse_NoComments_ID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(11205, result.id);
        }

        [TestMethod]
        public void geekListParse_NoComments_PostDate()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            DateTime expected = DateTime.Parse("Sat, 18 Nov 2006 20:12:46 +0000");

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.postDate);
        }

        [TestMethod]
        public void geekListParse_NoComments_PostTimeStamp()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("1163880766", result.postDateTimestamp);
        }

        [TestMethod]
        public void geekListParse_NoComments_EditDate()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            DateTime expected = DateTime.Parse("Tue, 03 Nov 2009 17:11:22 +0000");

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.editDate); 
        }

        [TestMethod]
        public void geekListParse_NoComments_EditTimeStamp()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("1257268282", result.editDateTimestamp);
        }

        [TestMethod]
        public void geekListParse_NoComments_Thumbs()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(90, result.thumbs);
        }

        [TestMethod]
        public void geekListParse_NoComments_NumItems()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(20, result.numItems);
        }

        [TestMethod]
        public void geekListParse_NoComments_Username()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("zefquaavius", result.userName);
        }

        [TestMethod]
        public void geekListParse_NoComments_Title()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("Segregation in Carcassonne!", result.title);
        }

        [TestMethod]
        public void geekListParse_NoComments_Description()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "You've mixed all your Carcassonne expansions together for the massive, every-expansion game.  Now you want to separate them to try a simple mix of no expansions, or only one with the original.  How are you going to tackle this daunting task?  Easy!  Look at the photos in this inventory, and parse the tiles appropriately.  (I recommend focusing on the expansions, and letting the original Carcassonne's 72 tiles remain as the distillate.)";

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.description);
        }

        [TestMethod]
        public void geekListParse_NoComments_NoCmmentsReturned()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(0, result.comments.Count);
        }
    }

    [TestClass]
    public class XMLParserTest_List_WithComments
    {
        public string testDataRelativePath = "TestData/GeekListWithComments.xml";

        [TestMethod]
        public void geekListParse_Comments_CommentCount()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(2, result.comments.Count);
        }

        [TestMethod]
        public void geekListParse_Comments_Username()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(1, result.comments.Count(x => x.username == "rokuroku"));
        }

        [TestMethod]
        public void geekListParse_Comments_PostDate()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            DateTime expected = DateTime.Parse("Thu, 27 May 2010 13:32:48 +0000");

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.comments.First(x => x.username == "rokuroku").postDate);
        }

        [TestMethod]
        public void geekListParse_Comments_EditDate()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            DateTime expected = DateTime.Parse("Thu, 27 May 2010 13:32:48 +0000");

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.comments.First(x => x.username == "rokuroku").editDate); //Thu, 27 May 2010 13:32:48 +0000
        }

        [TestMethod]
        public void geekListParse_Comments_Thumbs()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(2, result.comments.First(x => x.username == "rokuroku").thumbs);
        }

        [TestMethod]
        public void geekListParse_Comments_CommentText()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "Why no listing for Cult, Siege and Creativity?";

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.comments.First(x => x.username == "rokuroku").commentText);
        }
    }

    [TestClass]
    public class XMLParserTest_ListItems
    {
        public string testDataRelativePath = "TestData/GeekList.xml";

        [TestMethod]
        public void geekListParse_NoComments_NumberOfListItems()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(20, result.items.Count);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(1, result.items.Count(x => x.id == 186615));
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemObjectType()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("thing", result.items.First(x => x.id == 186615).objectType);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemSubType()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("boardgame", result.items.First(x => x.id == 186615).subType);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemObjectID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(5405, result.items.First(x => x.id == 186615).objectID);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemObjectName()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("Carcassonne: Traders & Builders", result.items.First(x => x.id == 186615).objectName);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemUserName()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("rokuroku", result.items.First(x => x.id == 186615).userName);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemPostDate()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(new DateTime(2005, 11, 04, 02, 49, 54), result.items.First(x => x.id == 186615).postDate);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemEditDate()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(new DateTime(2007, 11, 05, 19, 58, 8), result.items.First(x => x.id == 186615).editDate);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemThumbs()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(1, result.items.First(x => x.id == 186615).thumbs);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemImageID()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(24630, result.items.First(x => x.id == 186615).imageID);
        }

        [TestMethod]
        public void geekListParse_NoComments_ListItemBody()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            string expected = "This is a safer version of the body to test.  Wooooo!";

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.items.First(x => x.id == 186615).body);
        }
    }

    [TestClass]
    public class XMLParserTest_ListItemComments
    {
        public string testDataRelativePath = "TestData/GeekListWithComments.xml";

        [TestMethod]
        public void geekListParse_Comments_ListItemCommentCount()
        {
            // Arrange
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testDataRelativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(2, result.items.First(x => x.id == 186614).comments.Count);
        }
    }
}
