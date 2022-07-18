using VS_Models;

namespace VS_DLRepositories.Orders
{
    public interface IDLOrdersRepo
    {
        Task<int> UploadBulkOrders(List<Order> orders);
        Task<List<Order>> GetAllOrders();
    }
}
