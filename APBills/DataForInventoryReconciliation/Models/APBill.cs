using System;
using System.Collections.Generic;
using System.Text;

namespace DataForInventoryReconciliation.Models
{
    public class APBill
    {
        public int APBillId { get; set; }                       // for EF model only
        public int Unique { get; set; }
        public float EnterTime { get; set; }
        public string EnterDate { get; set; }                   //string($date-time)
        public BillHeader HeaderInfo { get; set; }
        public BillPayee Payee { get; set; }
        public BillSupplier Supplier { get; set; }
        public BillCommentLine BillCommentLines { get; set; }
    }
}
