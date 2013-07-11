using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Objects
{
    public class GeekListItem
    {
        public int id { get; set; }
        public string objectType { get; set; }
        public string subType { get; set; }
        public int objectID { get; set; }
        public string objectName { get; set; }
        public string userName { get; set; }
        public DateTime postDate { get; set; }
        public DateTime editDate { get; set; }
        public int thumbs { get; set; }
        public int imageID { get; set; }
        public string body { get; set; }
        public List<GeekListComment> comments { get; set; }
    }
}
