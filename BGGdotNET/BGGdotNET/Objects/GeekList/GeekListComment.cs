using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Objects
{
    public class GeekListComment
    {
        public string username { get; set; }
        public string commentText { get; set; }
        public int thumbs { get; set; }
        public DateTime postDate { get; set; }
        public DateTime editDate { get; set; }
    }
}
