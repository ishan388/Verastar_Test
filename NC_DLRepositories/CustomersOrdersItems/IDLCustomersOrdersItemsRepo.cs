using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS_Models.ViewModels;

namespace VS_DLRepositories.CustomersOrdersItems
{
    public interface IDLCustomersOrdersItemsRepo
    {
        Task<List<VM_CustomersOrdersItems>> GetAllData();
    }
}
