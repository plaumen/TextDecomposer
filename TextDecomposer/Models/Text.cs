using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextDecomposer.Models
{
    public class Text
    {
        [XmlElement("sentence")]
        public List<Sentence> Sentences { get; set; }
    }
}
