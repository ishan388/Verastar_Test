using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.Orders
{
    public class BLOrdersRepo : IBLOrdersRepo
    {
        public Task<Response<int>> UploadBulkOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
