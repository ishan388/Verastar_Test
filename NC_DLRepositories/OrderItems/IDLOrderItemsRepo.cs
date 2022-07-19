using VS_Models;

namespace VS_DLRepositories.OrderItems
{
    public interface IDLOrderItemsRepo
    {
        Task<int> UploadBulkOrderItems(List<OrderItem> oItems);
        Task<int> UpdateBulkOrderItems(List<OrderItem> oItems);
        Task<List<OrderItem>> GetAllOrderItems();
    }
}
