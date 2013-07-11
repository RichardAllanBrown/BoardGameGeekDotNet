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
    public class GeekListXML
    {
        [TestMethod]
        public void geekList_DefaultSettings_ListIsRetreived()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();

            // Act
            var result = client.getGeekList(11205);

            // Assert
            Assert.AreEqual(11205, result.id);
        }

        [TestMethod]
        public void geekList_WithCommentsSetting_ListIsRetreivedWithComments()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();

            // Act
            var result = client.getGeekList(commentSettings.fetch, 11205);

            // Assert
            Assert.IsTrue(result.comments.Count > 0);
        }

        [TestMethod]
        public void geekList_WithCommentsSetting_ListItemsRetreivedWithComments()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();

            // Act
            var result = client.getGeekList(commentSettings.fetch, 11205);

            // Assert
            Assert.IsTrue(result.items.Any(x => x.comments.Count > 0));
        }
    }
}
