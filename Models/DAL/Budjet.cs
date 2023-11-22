using System;
using System.Collections.Generic;

#nullable disable

namespace Models.DAL
{
    public partial class Budjet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public decimal? Amount { get; set; }
        public int? BudjetTypeId { get; set; }
    }
}
