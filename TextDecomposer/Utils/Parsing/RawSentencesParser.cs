using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextDecomposer.Utils.Parsing
{
    public class RawSentencesParser : IRawSentencesParser
    {
        private const string StopCharsPattern = @"(\(\.+\)|\.|!|\?)+";

        public ICollection<string> Parse(string text)
        {
            var textWithoutNewLines = text.Replace(@"\n", string.Empty).Replace(@"\r", string.Empty);
            var textWithoutNonWordCharacters = Regex.Replace(textWithoutNewLines, @"[^a-zA-Z'-.?! ]+", string.Empty);

            return Regex.Split(textWithoutNonWordCharacters, StopCharsPattern).Where(s => !string.IsNullOrEmpty(s) && !Regex.Match(s, StopCharsPattern).Success).Select(s => s.Trim()).ToArray();
        }
    }
}