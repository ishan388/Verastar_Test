using VS_Models;

namespace VS_DLRepositories.Customers
{
    public interface IDLCustomersRepo
    {
        Task<int> UploadBulkCustomers(List<Customer> customers);
        Task<List<Customer>> GetAllCustomers();
    }
}
