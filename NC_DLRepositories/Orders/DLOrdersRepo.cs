using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using VS_Models;

namespace VS_DLRepositories.Orders
{
    public class DLOrdersRepo : IDLOrdersRepo
    {
        private MyShopContext dbCtx;

        public DLOrdersRepo(MyShopContext ctx)
        {
            dbCtx = ctx;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await dbCtx.Orders.ToListAsync();
        }

        public async Task<int> UploadBulkOrders(List<Order> orders)
        {
            try
            {
                await dbCtx.Orders.AddRangeAsync(orders);
                return await dbCtx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }
    }
}
