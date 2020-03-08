using System;
using System.Collections.Generic;
using System.Text;

namespace DataForInventoryReconciliation.Models
{
    public class BillCommentLine
    {
        public int BillCommentLineId { get; set; }
        public int CommentLineIndex { get; set; }
        public string CommentLineData { get; set; }
    }
}
