using TextDecomposer.Models;

namespace TextDecomposer.Utils.Parsing
{
    public class TextParser
    {
        private readonly ISentencesParser sentencesParser;

        public TextParser(ISentencesParser sentencesParser)
        {
            this.sentencesParser = sentencesParser;
        }

        public Text Parse(string text)
        {
            return new Text(this.sentencesParser.Parse(text));
        }
    }
}
