using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TextDecomposer.Extensions;
using TextDecomposer.Models;

namespace TextDecomposer.Utils.Conversion
{
    public static class TextConversionExtensions
    {
        public static string ToXmlString(this Text textToSerialize)
        {
            if (textToSerialize.IsEmpty())
            {
                return string.Empty;
            }

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            XmlSerializer xmlSerializer = new XmlSerializer(textToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, textToSerialize, namespaces);
                return textWriter.ToString().Trim();
            }
        }

        public static string ToCsv(this Text text)
        {

            if (text.IsEmpty())
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            var maxWordsInOneSentence = text.Sentences.Select(s => s.Words.Count).Max();

            var firstLine = string.Empty;
            for (int wordIndex = 1; wordIndex <= maxWordsInOneSentence; wordIndex++)
            {
                firstLine += $", Word {wordIndex}";
            }

            stringBuilder.AppendLine(firstLine);

            for (int sentenceIndex = 0; sentenceIndex < text.Sentences.Count; sentenceIndex++)
            {
                var sentenceLine = $"Sentence {sentenceIndex + 1}, " + string.Join(", ", text.Sentences[sentenceIndex].Words);
                stringBuilder.AppendLine(sentenceLine);
            }


            return stringBuilder.ToString().Trim();
        }
    }
}
