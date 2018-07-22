using System.Linq;
using TextDecomposer.Models;

namespace TextDecomposer.Extensions
{
    public static class TextExtensions
    {
        public static bool IsEmpty(this Text text)
        {
            return !text.Sentences.Any() || text.Sentences.All(s => !s.Words.Any());
        }
    }
}
