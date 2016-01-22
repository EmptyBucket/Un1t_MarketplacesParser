using System.Collections.Generic;

namespace ParseZakupki
{
    public interface IParser
    {
        IReadOnlyCollection<string> Parse(string text);
    }
}
