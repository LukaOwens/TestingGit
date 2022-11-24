using System;
using System.Collections.Generic;

namespace TechoLand
{
    public partial class Product
    {
        public string Article { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int TypeId { get; set; }
        public int SupplierId { get; set; }
        public decimal Cost { get; set; }
        public int DiscountTypeId { get; set; }
        public int Count { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public virtual DiscountType DiscountType { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual Type Type { get; set; } = null!;
    }
}
