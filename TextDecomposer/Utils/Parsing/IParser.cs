using System.Collections.Generic;

namespace TextDecomposer.Utils.Parsing
{
    public interface IParser<T>
    {
        ICollection<T> Parse(string text);
    }
}