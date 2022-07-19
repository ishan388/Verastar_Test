using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS_DLRepositories.CustomersOrdersItems;
using VS_Models.Common;
using VS_Models.ViewModels;

namespace VS_BLRepositories.CustomersOrdersItems
{
    public class BLCustomersOrdersItemsRepo: IBLCustomersOrdersItemsRepo
    {
        private IDLCustomersOrdersItemsRepo dlRepo;

        public BLCustomersOrdersItemsRepo(IDLCustomersOrdersItemsRepo _dlRepo)
        {
            dlRepo = _dlRepo;
        }

        public Task<Response<VM_CustomersOrdersItems>> GetAllData()
        {
            Response<VM_CustomersOrdersItems> res = new Response<VM_CustomersOrdersItems>();
            try
            {
                res.IsSuccess = true;
                res.Message = "list fetched successfully";
                res.DataList = dlRepo.GetAllData().Result.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching All data: " + ex.Message;
            }
            return Task.FromResult(res);
        }

        public Task<Response<VM_CustomersOrdersItems1>> GetAllData1()
        {
            Response<VM_CustomersOrdersItems1> res = new Response<VM_CustomersOrdersItems1>();
            try
            {
                res.IsSuccess = true;
                res.Message = "list fetched successfully";
                res.DataList = dlRepo.GetAllData1().Result.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Some Error While Fetching All data: " + ex.Message;
            }
            return Task.FromResult(res);
        }
    }
}
