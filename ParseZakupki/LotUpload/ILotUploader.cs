using System.Collections.Generic;
using ParseZakupki.Entity;

namespace ParseZakupki.LotUpload
{
    public interface ILotUploader
    {
        IReadOnlyCollection<PurchaseInformation> Upload();
    }
}