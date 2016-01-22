using System.Collections.Generic;

namespace ParseZakupki.Parser
{
    public interface IParser
    {
        IReadOnlyCollection<string> Parse(string text);
    }
}
