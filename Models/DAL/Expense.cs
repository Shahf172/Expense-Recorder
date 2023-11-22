using System;
using System.Collections.Generic;

#nullable disable

namespace Models.DAL
{
    public partial class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
