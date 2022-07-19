using VS_DLRepositories.OrderItems;
using VS_Models;
using VS_Models.Common;

namespace VS_BLRepositories.OrderItems
{
    public class BLOrderItemsRepo : IBLOrderItemsRepo
    {
        private IDLOrderItemsRepo dlRepo;

        public BLOrderItemsRepo(IDLOrderItemsRepo _dlRepo)
        {
            dlRepo = _dlRepo;
        }
        public Task<Response<OrderItem>> GetAllOrderItems()
        {
            Response<OrderItem> res = new Response<OrderItem>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Order Items list fetched successfully";
                res.DataList = dlRepo.GetAllOrderItems().Result.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching All Order Items: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<int>> UpdateBulkOrderItems(List<OrderItem> oItems)
        {
            Response<int> res = new Response<int>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Order Items updated successfully";
                res.Data = dlRepo.UpdateBulkOrderItems(oItems).Result;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Updating Some Order Items: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<int>> UploadBulkOrderItems(List<OrderItem> oItems)
        {
            Response<int> res = new Response<int>();
            try
            {
                res.IsSuccess = true;
                res.Message = "Order Items added successfully";
                res.Data = dlRepo.UploadBulkOrderItems(oItems).Result;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Adding Order Items: " + ex.Message;
            }
            return Task.FromResult(res);
        }
    }
}
