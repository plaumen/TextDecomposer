using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextDecomposer.Utils.Parsing
{
    public class WordsParser : IParser<string>
    {
        private const string EmptyCharsPattern = @"\s+";

        public ICollection<string> Parse(string text)
        {
            return Regex.Split(text, EmptyCharsPattern).Where(w => !string.IsNullOrEmpty(w) && !Regex.Match(w, EmptyCharsPattern).Success).Select(w => w.Trim()).ToArray();
        }
    }
}
