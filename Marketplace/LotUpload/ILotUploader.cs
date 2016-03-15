using System.Collections.Generic;
using MarketplaceDB;
using ParseZakupki.Entity;

namespace ParseZakupki.LotUpload
{
    public interface ILotUploader
    {
        IReadOnlyCollection<Marketplace> Upload();
    }
}