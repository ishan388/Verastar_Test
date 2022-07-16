using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.Customers
{
    public interface IBLCustomersRepo
    {
        Task<Response<int>> UploadBulkCustomers(List<Customer> customers);
    }
}
