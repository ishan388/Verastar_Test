using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using VS_Models;

namespace VS_DLRepositories.OrderItems
{
    public class DLOrderItemsRepo : IDLOrderItemsRepo
    {
        private MyShopContext dbCtx;

        public DLOrderItemsRepo(MyShopContext ctx)
        {
            dbCtx = ctx;
        }
        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            return await dbCtx.OrderItems.ToListAsync();
        }

        public async Task<int> UploadBulkOrderItems(List<OrderItem> oItems)
        {
            using (var transaction = dbCtx.Database.BeginTransaction())
            {
                await dbCtx.BulkInsertAsync(oItems);
                transaction.Commit();
            }
            return 1;
        }
    }
}
