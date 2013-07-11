using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Objects
{
    public class GeekList
    {
        public int id { get; set; }
        public DateTime postDate { get; set; }
        public string postDateTimestamp { get; set; }
        public DateTime editDate { get; set; }
        public string editDateTimestamp { get; set; }
        public int thumbs { get; set; }
        public int numItems { get; set; }
        public string userName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<GeekListItem> items { get; set; }
    }
}
