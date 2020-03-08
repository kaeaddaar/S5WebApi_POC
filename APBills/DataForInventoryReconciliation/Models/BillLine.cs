using System;
using System.Collections.Generic;
using System.Text;

namespace DataForInventoryReconciliation.Models
{
    public class BillLine
    {
        public int BillLineId { get; set; }             // for EF model only
        public int? BillUnique { get; set; }
        public string DataDate { get; set; }            // Contains $date-time
        public int Department { get; set; }
        public int CurrencyCode { get; set; }
        public int Supplier { get; set; }
        public int WholeCurrencyCode { get; set; }
        public string LedgerAccount { get; set; }
        public string LedgerAccountName { get; set; }
        public string Description { get; set; }
        public string DbCd { get; set; }
        public float Amount { get; set; }
        public string CurrencyDate { get; set; }        // contains $date-time

    }
}
