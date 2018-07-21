using FluentAssertions;
using NSubstitute;
using System.Linq;
using TextDecomposer.Utils.Parsing;

namespace TextDecomposerTests.Parsing
{
    public class SentencesParserTests
    {
        private IRawSentencesParser rawSentencesParser = Substitute.For<IRawSentencesParser>();
        private IWordsParser wordsParser = Substitute.For<IWordsParser>();
        private SentencesParser sentencesParser;

        public SentencesParserTests()
        {
            sentencesParser = new SentencesParser(rawSentencesParser, wordsParser);
        }

        public void WhenTextIsRegular_Parse_ShouldReturnOrderedWords()
        {
            //arrange
            rawSentencesParser.Parse(Arg.Any<string>()).Returns(new string[] { "sentence 1", "sentence 2" });
            wordsParser.Parse(Arg.Any<string>()).Returns(new string[] { "zebra", "lion", "elephant" });
            var expectedWordsOrder = new string[] { "elephant", "lion", "zebra" };

            //act
            var sentences = sentencesParser.Parse("random text");

            //assert
            sentences.Should().HaveCount(2);
            sentences.ElementAt(0).Words.Should().BeEquivalentTo(expectedWordsOrder);
        }

    }
}
