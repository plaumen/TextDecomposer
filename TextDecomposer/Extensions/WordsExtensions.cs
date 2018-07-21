using System.Collections.Generic;
using TextDecomposer.Models;

namespace TextDecomposer.Extensions
{
    public static class WordsExtensions
    {
        public static Sentence ToSentence(this ICollection<string> words)
        {
            return new Sentence { Words = new List<string>(words) };
        }
    }
}
