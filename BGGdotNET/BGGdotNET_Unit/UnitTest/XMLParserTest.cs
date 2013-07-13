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
        [TestMethod]
        public void GeekListParse_NoComments_ID()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(11205, result.id);
        }

        [TestMethod]
        public void GeekListParse_NoComments_PostDate()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(new DateTime(2006, 11, 18, 20, 12, 46), result.postDate);
        }

        [TestMethod]
        public void GeekListParse_NoComments_PostTimeStamp()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("1163880766", result.postDateTimestamp);
        }

        [TestMethod]
        public void GeekListParse_NoComments_EditDate()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(new DateTime(2009, 11, 03, 17, 11, 22), result.editDate); 
        }

        [TestMethod]
        public void GeekListParse_NoComments_EditTimeStamp()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("1257268282", result.editDateTimestamp);
        }

        [TestMethod]
        public void GeekListParse_NoComments_Thumbs()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(90, result.thumbs);
        }

        [TestMethod]
        public void GeekListParse_NoComments_NumItems()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(20, result.numItems);
        }

        [TestMethod]
        public void GeekListParse_NoComments_Username()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("zefquaavius", result.userName);
        }

        [TestMethod]
        public void GeekListParse_NoComments_Title()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("Segregation in Carcassonne!", result.title);
        }

        [TestMethod]
        public void GeekListParse_NoComments_Description()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            string expected = "You've mixed all your Carcassonne expansions together for the massive, every-expansion game.  Now you want to separate them to try a simple mix of no expansions, or only one with the original.  How are you going to tackle this daunting task?  Easy!  Look at the photos in this inventory, and parse the tiles appropriately.  (I recommend focusing on the expansions, and letting the original Carcassonne's 72 tiles remain as the distillate.)";

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.description);
        }

        [TestMethod]
        public void GeekListParse_NoComments_NoCmmentsReturned()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(0, result.comments.Count);
        }
    }

    [TestClass]
    public class XMLParserTest_ListItems
    {
        [TestMethod]
        public void GeekListParse_NoComments_NumberOfListItems()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(20, result.items.Count);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemID()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(1, result.items.Count(x => x.id == 186615));
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemObjectType()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("thing", result.items.First(x => x.id == 186615).objectType);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemSubType()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("boardgame", result.items.First(x => x.id == 186615).subType);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemObjectID()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(5405, result.items.First(x => x.id == 186615).objectID);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemObjectName()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("Carcassonne: Traders & Builders", result.items.First(x => x.id == 186615).objectName);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemUserName()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual("rokuroku", result.items.First(x => x.id == 186615).userName);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemPostDate()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(new DateTime(2005, 11, 04, 02, 49, 54), result.items.First(x => x.id == 186615).postDate);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemEditDate()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(new DateTime(2007, 11, 05, 19, 58, 8), result.items.First(x => x.id == 186615).editDate);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemThumbs()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(1, result.items.First(x => x.id == 186615).thumbs);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemImageID()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(24630, result.items.First(x => x.id == 186615).imageID);
        }

        [TestMethod]
        public void GeekListParse_NoComments_ListItemBody()
        {
            // Arrange
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            string expected = "2003 [b]Carcassonne: Traders &amp; Builders[/b]" +
                              "24 land tiles (20 have goods on them, which are rather conspicuous)" +
                              "20 trade good tokens (9 wine, 6 grain, 5 cloth)" +
                              "1 pig × 6 colors (blue, yellow, green, red, black, grey)" +
                              "1 builder × 6 colors (blue, yellow, green, red, black, grey)" +
                              "1 cloth bag [It&#039;s about time!!]";

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(expected, result.items.First(x => x.id == 186615).body);
        }
    }
}
