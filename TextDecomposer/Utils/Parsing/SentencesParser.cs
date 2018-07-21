using System.Collections.Generic;
using TextDecomposer.Extensions;
using TextDecomposer.Models;

namespace TextDecomposer.Utils.Parsing
{
    public class SentencesParser : ISentencesParser
    {
        private IRawSentencesParser rawSentencesParser;
        private IWordsParser wordsParser;

        public SentencesParser(IRawSentencesParser rawSentencesParser, IWordsParser wordsParser)
        {
            this.rawSentencesParser = rawSentencesParser;
            this.wordsParser = wordsParser;
        }

        public ICollection<Sentence> Parse(string text)
        {
            var sentences = new List<Sentence>();

            foreach (var rawSentence in rawSentencesParser.Parse(text))
            {
                var words = wordsParser.Parse(rawSentence);

                sentences.Add(words.ToSentence());
            }

            return sentences;
        }
    }
}
