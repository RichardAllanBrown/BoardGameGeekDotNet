using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

using BGGdotNET.Client;
using BGGdotNET.Objects;

namespace BGGdotNET_Test.UnitTest
{
    /// <summary>
    /// XML Parser Test uses test data from BGG api to ensure objects are correctly parsed
    /// </summary>
    [TestClass]
    public class XMLParserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            IXMLParser parser = new XMLParser();
            XDocument testData = XDocument.Load("/TestData/XML_SimpleGeekList.xml");

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(11205, result.id);
        }
    }
}
