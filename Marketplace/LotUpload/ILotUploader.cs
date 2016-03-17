using System.Collections.Generic;
using MarketplaceLocalDB;

namespace ParseZakupki.LotUpload
{
    public interface ILotUploader
    {
        IReadOnlyCollection<Lot> Upload();
    }
}