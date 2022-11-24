using System;
using System.Collections.Generic;

namespace TechoLand
{
    public partial class OrderProduct
    {
        public int OrderId { get; set; }
        public string Articule { get; set; } = null!;
        public int Count { get; set; }

        public virtual Product ArticuleNavigation { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
