using VS_DLRepositories.Orders;
using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.Orders
{
    public class BLOrdersRepo : IBLOrdersRepo
    {
        private IDLOrdersRepo dlRepo;

        public BLOrdersRepo(IDLOrdersRepo _dlRepo)
        {
            dlRepo = _dlRepo;
        }
        public Task<Response<Order>> GetAllOrders()
        {
            Response<Order> res = new Response<Order>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Orders list fetched successfully";
                res.DataList = dlRepo.GetAllOrders().Result.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching All Orders: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<int>> UploadBulkOrders(List<Order> orders)
        {
            Response<int> res = new Response<int>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Orders added successfully";
                res.Data = dlRepo.UploadBulkOrders(orders).Result;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Adding Orders: " + ex.Message;
            }
            return Task.FromResult(res);
        }
    }
}
