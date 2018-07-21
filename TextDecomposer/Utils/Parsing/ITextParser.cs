using TextDecomposer.Models;

namespace TextDecomposer.Utils.Parsing
{
    public interface ITextParser
    {
        Text Parse(string text);
    }
}