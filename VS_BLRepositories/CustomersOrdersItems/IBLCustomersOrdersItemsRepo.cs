using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS_Models.Common;
using VS_Models.ViewModels;

namespace VS_BLRepositories.CustomersOrdersItems
{
    public interface IBLCustomersOrdersItemsRepo
    {
        Task<Response<VM_CustomersOrdersItems>> GetAllData();
    }
}
