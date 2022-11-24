using System;
using System.Collections.Generic;

namespace TechoLand
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
