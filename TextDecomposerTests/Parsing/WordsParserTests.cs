using FluentAssertions;
using System.Linq;
using TextDecomposer.Utils.Parsing;
using Xunit;

namespace TextDecomposerTests.Parsing
{
    public class WordsParserTests
    {
        private WordsParser wordsParser = new WordsParser();

        [Fact]
        public void WhenStringSeparetedBySpaces_Parse_ShouldTreatThemAsWords()
        {
            //arrange
            var text = "word second-word another word";

            //act
            var words = wordsParser.Parse(text);

            //assert
            words.Should().HaveCount(4);
            words.ElementAt(1).Should().Be("second-word");
        }

        [Fact]
        public void WhenMultipleSpacesAreInText_Parse_ShouldTrimThem()
        {
            //arrange
            var multipleSpacesText = "word                          second                       third";

            //act
            var words = wordsParser.Parse(multipleSpacesText);

            //assert
            words.Should().HaveCount(3);
            words.ElementAt(0).Should().Be("word");
            words.ElementAt(1).Should().Be("second");
            words.ElementAt(2).Should().Be("third");
        }
    }
}
