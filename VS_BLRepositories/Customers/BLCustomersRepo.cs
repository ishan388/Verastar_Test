using VS_DLRepositories.Customers;
using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.Customers
{
    public class BLCustomersRepo : IBLCustomersRepo
    {
        private IDLCustomersRepo dlRepo;

        public BLCustomersRepo(IDLCustomersRepo _dlRepo)
        {
            dlRepo = _dlRepo;
        }

        public Task<Response<Customer>> GetAllCustomers()
        {
            Response<Customer> res = new Response<Customer>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Customers list fetched successfully";
                res.DataList = dlRepo.GetAllCustomers().Result.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching All Customers: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<int>> UploadBulkCustomers(List<Customer> customers)
        {
            throw new NotImplementedException();
        }
    }
}