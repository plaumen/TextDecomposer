using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TextDecomposer.Models
{
    public class Sentence
    {
        private List<string> _words;

        [XmlElement("word")]
        public List<string> Words
        {
            get => _words.OrderBy(word => word).ToList();
            set => _words = value;
        }
    }
}
