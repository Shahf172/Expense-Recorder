using System;
using System.Collections.Generic;

#nullable disable

namespace Models.DAL
{
    public partial class BudjetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? DataEntryDate { get; set; }
    }
}
