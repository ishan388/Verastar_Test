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
            try
            {
                var qry = (from c in dbCtx.Customers
                           join o in dbCtx.Orders on c.Id equals o.CustomerId
                           join oi in dbCtx.OrderItems on o.Id equals oi.OrderId
                           select new
                           {
                               CustomerId = c.Id,
                               State = c.State,
                               Email = c.Email,
                               Fullname = (c.Firstname + " " + c.Lastname),
                               OrderId = o.Id,
                               Discount = oi.Discount,
                               ListPrice = oi.ListPrice
                           }).AsQueryable().ToList();

                var res = qry
                    .GroupBy(g => new { g.OrderId, g.CustomerId, g.Email, g.Fullname, g.State })
                    .Select(s => new VM_CustomersOrdersItems()
                    {
                        TotalListPrice = s.Sum(e => e.ListPrice),
                        TotalDiscount = s.Sum(e => (e.Discount * e.ListPrice)),
                        Fullname = s.Key.Fullname,
                        CustomerId = s.Key.CustomerId,
                        Email = s.Key.Email,
                        OrderId = s.Key.OrderId,
                        State = s.Key.State,
                    }).OrderBy(x => x.CustomerId).ToList();

                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
