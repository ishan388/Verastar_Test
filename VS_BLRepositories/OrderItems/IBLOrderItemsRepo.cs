using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.OrderItems
{
    public interface IBLOrderItemsRepo
    {
        Task<Response<int>> UploadBulkOrderItems(List<OrderItem> oItems);
        Task<Response<int>> UpdateBulkOrderItems(List<OrderItem> oItems);
        Task<Response<OrderItem>> GetAllOrderItems();
    }
}
