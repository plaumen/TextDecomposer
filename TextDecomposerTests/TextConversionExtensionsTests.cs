using FluentAssertions;
using System.Collections.Generic;
using TextDecomposer.Models;
using TextDecomposer.Utils.Conversion;
using Xunit;

namespace TextDecomposerTests
{
    public class TextConversionExtensionsTests
    {
        [Fact]
        public void WhenAnySentences_ToXmlString_ShouldReturnValidXmlString()
        {
            //arrange
            var sentences = new Sentence[] { new Sentence { Words = new List<string>(new string[] { "one", "two" }) }, new Sentence { Words = new List<string>(new string[] { "nine", "four" }) } };
            var text = new Text(sentences);
            var expectedXmlString = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text>
  <sentence>
    <word>one</word>
    <word>two</word>
  </sentence>
  <sentence>
    <word>four</word>
    <word>nine</word>
  </sentence>
</text>";

            //act
            var xml = text.ToXmlString();

            //assert
            xml.Should().Be(expectedXmlString);
        }

        [Fact]
        public void WhenAnySentences_ToCsv_ShouldReturnValidCsvContent()
        {
            //arrange
            var sentences = new Sentence[] { new Sentence { Words = new List<string>(new string[] { "one", "two", "one" }) }, new Sentence { Words = new List<string>(new string[] { "nine", "four" }) } };
            var text = new Text(sentences);
            var expectedString = @", Word 1, Word 2, Word 3
Sentence 1, one, one, two
Sentence 2, four, nine";

            //act
            var csv = text.ToCsv();

            //assert
            csv.Should().Be(expectedString);
        }

        [Fact]
        public void WhenNoSentences_ToCsv_ShouldReturnEmptyString()
        {
            //arrange
            var text = new Text();

            //act
            var csv = text.ToCsv();

            //assert
            csv.Should().Be(string.Empty);
        }

        [Fact]
        public void WhenNoSentences_ToXml_ShouldReturnEmptyString()
        {
            //arrange
            var text = new Text();

            //act
            var xml = text.ToXmlString();

            //assert
            xml.Should().Be(string.Empty);
        }
    }
}
