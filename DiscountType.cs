using System;
using System.Collections.Generic;

namespace TechoLand
{
    public partial class DiscountType
    {
        public DiscountType()
        {
            Products = new HashSet<Product>();
        }

        public int DiscountTypeId { get; set; }
        public string Name { get; set; } = null!;
        public int Discount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
