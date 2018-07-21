using FluentAssertions;
using System.Linq;
using TextDecomposer.Utils.Parsing;
using Xunit;

namespace TextDecomposerTests.Parsing
{
    public class RawSentencesParserTests
    {
        private RawSentencesParser rawSentencesParser = new RawSentencesParser();

        public RawSentencesParserTests()
        {

        }

        [Fact]
        public void WhenNoSentenceEndingChars_Parse_ShouldReturnInputString()
        {
            //arrange
            var noEndingCharsString = "text without dot, question and exclamation mark";

            //act
            var sentences = rawSentencesParser.Parse(noEndingCharsString);

            //assert
            sentences.Should().HaveCount(1);
            sentences.First().Should().Be(noEndingCharsString);
        }

        [Fact]
        public void WhenTextContainsDots_Parse_ShouldReturnMultipleItems()
        {
            //arrange
            var textWithDots = "first sentence. second sentence. third sentence";

            //act
            var sentences = rawSentencesParser.Parse(textWithDots);

            //assert
            sentences.Should().HaveCount(3);
            sentences.ElementAt(0).Should().Be("first sentence");
            sentences.ElementAt(1).Should().Be("second sentence");
            sentences.ElementAt(2).Should().Be("third sentence");
        }

        [Fact]
        public void WhenTextContainsMultipleDots_Parse_ShouldRecognizedItAsEndOfSentence()
        {
            //arrange
            var multipleDotsText = "first sentence with multiple dots... another text";

            //act
            var sentences = rawSentencesParser.Parse(multipleDotsText);

            //assert
            sentences.Should().HaveCount(2);
            sentences.ElementAt(0).Should().Be("first sentence with multiple dots");
            sentences.ElementAt(1).Should().Be("another text");
        }

        [Fact]
        public void WhenTextContainsMultipleDotsInBrackets_Parse_ShouldRecognizeItAsEndOfSentence()
        {
            //arrange
            var multipleDotsInBracketsText = "first row(...) second row... what else?";

            //act
            var sentences = rawSentencesParser.Parse(multipleDotsInBracketsText);

            //assert
            sentences.Should().HaveCount(3);
            sentences.ElementAt(0).Should().Be("first row");
            sentences.ElementAt(1).Should().Be("second row");
            sentences.ElementAt(2).Should().Be("what else");
        }

        [Fact]
        public void WhenTextContainsQuestionMark_Parse_ShouldRecognizeItAsTheEndOfSentence()
        {
            //arrange
            var textWithQuestionMark = "what? do you do";

            //act
            var sentences = rawSentencesParser.Parse(textWithQuestionMark);

            //assert
            sentences.Should().HaveCount(2);
            sentences.ElementAt(0).Should().Be("what");
            sentences.ElementAt(1).Should().Be("do you do");
        }

        [Fact]
        public void WhenTextContainsExclamationMark_Parse_ShouldRecognizeItAsTheEndOfSentence()
        {
            //arrange
            var textWithExclamationMark = "wow! you are incredible";

            //act
            var sentences = rawSentencesParser.Parse(textWithExclamationMark);

            //assert
            sentences.Should().HaveCount(2);
            sentences.ElementAt(0).Should().Be("wow");
            sentences.ElementAt(1).Should().Be("you are incredible");
        }

        [Fact]
        public void WhenSentenceIsInMultipleLines_Parse_ShouldTreatIsAsOne()
        {
            //arrange
            var textWithSentenceInMultipleLines = @"wow! my father\n died";

            //act
            var sentences = rawSentencesParser.Parse(textWithSentenceInMultipleLines);

            //assert
            sentences.Should().HaveCount(2);
            sentences.ElementAt(0).Should().Be("wow");
            sentences.ElementAt(1).Should().Be("my father died");
        }

        [Fact]
        public void WhenNotStandardCharactersOccurs_Parse_ShouldOmitThem()
        {
            //arrange 
            var notStandardCharactersText = "music;! price: 10$. &&&very cheap    ?";

            //act
            var sentences = rawSentencesParser.Parse(notStandardCharactersText);

            //assert
            sentences.Should().HaveCount(3);
            sentences.ElementAt(0).Should().Be("music");
            sentences.ElementAt(1).Should().Be("price");
            sentences.ElementAt(2).Should().Be("very cheap");
        }
    }
}