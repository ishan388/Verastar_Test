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
            using (var transaction = dbCtx.Database.BeginTransaction())
            {
                await dbCtx.BulkInsertAsync(orders);
                transaction.Commit();
            }
            return 1;
        }
    }
}
