//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketplaceLocalDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Marketplace1
    {
        public int Id { get; set; }
        public Nullable<int> LotId { get; set; }
        public Nullable<int> InfroId { get; set; }
    
        public virtual InformationOnMarketplace InformationOnMarketplace { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
