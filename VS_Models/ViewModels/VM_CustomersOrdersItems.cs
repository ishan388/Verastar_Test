﻿namespace VS_Models.ViewModels
{
    public class VM_CustomersOrdersItems
    {
        public int CustomerId { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string State { get; set; } = null!;
        public int? OrderId { get; set; } = null!;
        public decimal? TotalListPrice { get; set; } = 0;
        public decimal? TotalDiscount { get; set; } = 0;
        public decimal? FinalPrice
        {
            get { return (TotalListPrice - TotalDiscount); }
        }
    }
}
