﻿using VS_Models.Common;
using VS_Models.ViewModels;

namespace VS_BLRepositories.CustomersOrdersItems
{
    public interface IBLCustomersOrdersItemsRepo
    {
        Task<Response<VM_CustomersOrdersItems>> GetAllData();
        Task<Response<VM_CustomersOrdersItems1>> GetAllData1();
    }
}
