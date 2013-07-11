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
            var result = client.getGeekList(commentSettings.none, 11205);

            // Assert
            Assert.AreEqual(11205, result.id);
        }
    }
}
