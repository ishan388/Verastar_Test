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

        public async Task<int> UpdateBulkOrderItems(List<OrderItem> oItems)
        {
            using var transaction = dbCtx.Database.BeginTransaction();
            try
            {
                foreach (OrderItem? item in oItems)
                {
                    OrderItem? orderItemtoUpdate = dbCtx.OrderItems.Where(e => e.Id == item.Id).FirstOrDefault();
                    if (orderItemtoUpdate != null)
                    {
                        orderItemtoUpdate.Discount = item.Discount;
                        orderItemtoUpdate.ItemId = item.ItemId;
                        orderItemtoUpdate.ListPrice = item.ListPrice;
                        orderItemtoUpdate.OrderId = item.OrderId;
                        await dbCtx.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
            await transaction.CommitAsync();
            return oItems.Count;
        }

        public async Task<int> UploadBulkOrderItems(List<OrderItem> oItems)
        {
            try
            {
                await dbCtx.OrderItems.AddRangeAsync(oItems);
                return await dbCtx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
