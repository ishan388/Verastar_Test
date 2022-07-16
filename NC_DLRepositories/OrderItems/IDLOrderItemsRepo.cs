using VS_Models;

namespace VS_DLRepositories.OrderItems
{
    public interface IDLOrderItemsRepo
    {
        Task<int> UploadBulkOrderItems(List<OrderItem> oItems);
    }
}
