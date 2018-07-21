using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextDecomposer.Models
{
    [XmlRoot("text")]
    public class Text
    {
        public Text(ICollection<Sentence> sentences)
        {
            this.Sentences = new List<Sentence>(sentences);
        }

        public Text()
        {

        }

        [XmlElement("sentence")]
        public List<Sentence> Sentences { get; set; }
    }
}
