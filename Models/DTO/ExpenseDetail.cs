using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class ExpenseDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExpType { get; set; }
        public string PaymentMode { get; set; }
        public decimal? Amount { get; set; }
        public int? ExpenseTypeId { get; set; }
        public int? PaymentModeId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? DataEntryDate { get; set; }
    }
}
