using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.OrderItems
{
    public class BLOrderItemsRepo : IBLOrderItemsRepo
    {
        public Task<Response<int>> UploadBulkOrderItems(List<OrderItem> oItems)
        {
            throw new NotImplementedException();
        }
    }
}
