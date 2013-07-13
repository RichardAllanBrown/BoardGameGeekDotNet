using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using BGGdotNET.Objects;

namespace BGGdotNET.Client
{
    public interface IXMLParser
    {
        List<BoardGame> parseBoardGameXML(XDocument input);
        List<BGSearchResult> parseSearchXML(XDocument input);
        List<CollectionItem> parseCollectionXML(XDocument input);
        GeekList parseGeekListXML(XDocument input);
    }
}
