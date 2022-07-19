using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS_Models.ViewModels;

namespace VS_DLRepositories.CustomersOrdersItems
{
    public class DLCustomersOrdersItemsRepo : IDLCustomersOrdersItemsRepo
    {
        private MyShopContext dbCtx;

        public DLCustomersOrdersItemsRepo(MyShopContext ctx)
        {
            dbCtx = ctx;
        }

        public async Task<List<VM_CustomersOrdersItems>> GetAllData()
        {
            return (from c in dbCtx.Customers
                join o in dbCtx.Orders on c.Id equals o.CustomerId into ord
                from ordOrNull in ord.DefaultIfEmpty()
                join oi in dbCtx.OrderItems on ordOrNull.Id equals oi.OrderId into ordItms
                from ordItmsOrNUll in ordItms.DefaultIfEmpty()
                select new VM_CustomersOrdersItems()
                {
                    CustomerId = c.Id,
                    OrderId = ordOrNull.Id,
                    OrderDate = ordOrNull.OrderDate,
                    City = c.City,
                    Discount = ordItmsOrNUll.Discount,
                    Email = c.Email,
                    Fullname = (c.Firstname + " " + c.Lastname),
                    ItemId = ordItmsOrNUll.ItemId,
                    ListPrice = ordItmsOrNUll.ListPrice,
                    OrderItemsId = ordItmsOrNUll.Id,
                    State = c.State
                }).AsQueryable().ToList();
        }
    }
}
