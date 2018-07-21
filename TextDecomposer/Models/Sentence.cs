using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TextDecomposer.Models
{
    public class Sentence
    {
        public Sentence(ICollection<string> words)
        {
            this.Words = new List<string>(words.OrderBy(word => word));
        }

        [XmlElement("word")]
        public List<string> Words { get; set; }
    }
}
