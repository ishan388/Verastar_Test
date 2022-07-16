using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.Customers
{
    public class BLCustomersRepo : IBLCustomersRepo
    {
        public Task<Response<int>> UploadBulkCustomers(List<Customer> customers)
        {
            throw new NotImplementedException();
        }
    }
}