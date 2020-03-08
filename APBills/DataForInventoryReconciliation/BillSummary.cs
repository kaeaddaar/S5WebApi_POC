using System;
using System.Collections.Generic;
using System.Text;

namespace DataForInventoryReconciliation
{
    public class BillSummary
    {
        public int BillId { get; set; }
        public int? WWS5Unique { get; set; }    // leave null until loaded later from System Five. 
                                                // The S5WebAPI doesn't export unique, so I'll attach later.
        public string BillNumber { get; set; }
        public string BillDescription { get; set; }
        public string BillPO { get; set; }
        public int Supplier { get; set; }
        public int Pay { get; set; } // Payee
        public float Total { get; set; }


    }
}
