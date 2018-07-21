using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextDecomposer.Models
{
    public class Sentence
    {
        [XmlElement("word")]
        public List<string> Words { get; set; }
    }
}
