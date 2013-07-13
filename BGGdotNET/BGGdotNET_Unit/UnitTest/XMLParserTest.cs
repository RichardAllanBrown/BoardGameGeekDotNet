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
            string relativePath = "TestData/XML_SimpleGeekList.xml";
            XDocument testData = XDocument.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

            IXMLParser parser = new XMLParser();

            // Act
            var result = parser.parseGeekListXML(testData);

            // Assert
            Assert.AreEqual(11205, result.id);
        }
    }
}
