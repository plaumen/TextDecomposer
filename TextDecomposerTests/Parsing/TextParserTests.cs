using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using TextDecomposer.Models;
using TextDecomposer.Utils.Parsing;
using Xunit;

namespace TextDecomposerTests.Parsing
{
    public class TextParserTests
    {
        private ISentencesParser sentencesParserMock = Substitute.For<ISentencesParser>();

        private TextParser textParser;

        public TextParserTests()
        {
            this.textParser = new TextParser(sentencesParserMock);
        }

        [Fact]
        public void WhenTextToParse_Parse_ShouldReturnTextContainingSentences()
        {
            //arrange
            var expectedSentences = new Sentence[] { new Sentence { Words = new List<string>(new string[] { "w", "1" }) }, new Sentence { Words = new List<string>(new string[] { "w", "1" }) } };
            sentencesParserMock.Parse(Arg.Any<string>()).Returns(expectedSentences);

            //act
            var text = this.textParser.Parse("any text");

            //assert
            text.Sentences.Should().BeEquivalentTo(expectedSentences);
        }
    }
}
