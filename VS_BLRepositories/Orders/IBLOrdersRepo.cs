using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.Orders
{
    public interface IBLOrdersRepo
    {
        Task<Response<int>> UploadBulkOrders(List<Order> orders);
        Task<Response<Order>> GetAllOrders();
    }
}
