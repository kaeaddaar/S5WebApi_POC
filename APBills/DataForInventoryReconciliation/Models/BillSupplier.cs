using System;
using System.Collections.Generic;
using System.Text;

namespace DataForInventoryReconciliation.Models
{
    public class BillSupplier
    {
        public int BillSupplierId { get; set; }        // for EF model only
        public int ContextUnique { get; set; }
        public int Location { get; set; }
        public int Unique { get; set; }
        public string AName { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public string Country { get; set; }
        public string CountryName { get; set; }
        public string Phone_1 { get; set; }
    }
}
