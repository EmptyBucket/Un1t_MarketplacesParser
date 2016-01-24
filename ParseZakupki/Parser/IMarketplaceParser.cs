using System.Collections.Generic;

namespace ParseZakupki.Parser
{
    public interface IMarketplaceParser
    {
        IReadOnlyCollection<PurchaseInformation> Parse(string txtDoc);
    }
}
