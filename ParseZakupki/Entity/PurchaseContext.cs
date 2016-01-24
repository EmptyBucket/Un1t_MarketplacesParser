﻿using System.Data.Entity;

namespace ParseZakupki.Entity
{
    public class PurchaseInformationContext : DbContext
    {
        public DbSet<PurchaseInformation> Purchase { get; set; }
        public DbSet<ZakupkiParametersDb> Parameters { get; set; }
    }
}
