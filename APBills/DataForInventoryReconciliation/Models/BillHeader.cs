using System;
using System.Collections.Generic;
using System.Text;

namespace DataForInventoryReconciliation.Models
{
    public class BillHeader
    {
        public int BillHeaderId { get; set; }       // for EF model only
        public string Number { get; set; }
        public string PO { get; set; }
        public string Description { get; set; }
        public string Foreign { get; set; }
        public int Pay { get; set; }                // Payee
        public int Supplier { get; set; }
        public float Total { get; set; }
        public string Date { get; set; }            // string($date-time)
        public int Department { get; set; }
        public string DueDate { get; set; }
    }
}
