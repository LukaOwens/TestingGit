using System;
using System.Collections.Generic;

namespace TechoLand
{
    public partial class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
