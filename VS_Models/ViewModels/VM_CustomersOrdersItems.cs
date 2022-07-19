using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Models.ViewModels
{
    public class VM_CustomersOrdersItems
    {
        public int CustomerId { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public int? OrderId { get; set; } = null!;
        public DateTime? OrderDate { get; set; } = null!;
        public int? OrderItemsId { get; set; } = null!;
        public int? ItemId { get; set; } = null!;
        public decimal? ListPrice { get; set; } = 0;
        public decimal? Discount { get; set; } = 0;
        public decimal? FinalPrice
        {
            get { return (ListPrice - (ListPrice * Discount)); }
        }
    }
}
