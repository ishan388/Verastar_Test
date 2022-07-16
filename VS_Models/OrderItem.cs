using System;
using System.Collections.Generic;

namespace VS_Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
