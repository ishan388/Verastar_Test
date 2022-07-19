using System;
using System.Collections.Generic;
using System.Linq;
using VS_DLRepositories.CustomersOrdersItems;
using VS_Models.ViewModels;
using Xunit;

namespace VS_DLRepositories.Tests
{
    public class DLCustomersOrdersItemsRepoTests
    {
        private IDLCustomersOrdersItemsRepo dlRepo;

        List<VM_CustomersOrdersItems> data = new List<VM_CustomersOrdersItems>()
        {
            new VM_CustomersOrdersItems()
            {
                CustomerId= 2,
                Fullname= "Kasha Todd",
                Email= "kasha.todd@yahoo.com",
                City= "Campbell",
                State= "CA",
                OrderId= 1084,
                OrderDate= new DateTime(2017,08,20),
                OrderItemsId= 90,
                ItemId= 5,
                ListPrice= 1559.99m,
                Discount= 0.10m,
            },
            new VM_CustomersOrdersItems()
            {
                CustomerId= 3,
                Fullname= "Tameka Fisher",
                Email= "tameka.fisher@aol.com",
                City= "Redondo Beach",
                State= "CA",
                OrderId= null,
                OrderDate= null,
                OrderItemsId= null,
                ItemId= null,
                ListPrice= null,
                Discount= null,
            }
        };

        [Fact]
        public void GetAllCustomers_Test()
        {
            using (var ctx = DbContextFactory.Create())
            {
                dlRepo = new DLCustomersOrdersItemsRepo(ctx);
                List<VM_CustomersOrdersItems> result = dlRepo.GetAllData().Result;

                foreach (VM_CustomersOrdersItems res in data)
                {
                    Assert.Contains(res.CustomerId, result.Select(x => x.CustomerId));
                    Assert.Contains(res.Fullname, result.Select(x => x.Fullname));
                    Assert.Contains(res.Email, result.Select(x => x.Email));
                    Assert.Contains(res.City, result.Select(x => x.City));
                    Assert.Contains(res.State, result.Select(x => x.State));
                    Assert.Contains(res.OrderId, result.Select(x => x.OrderId));
                    Assert.Contains(res.OrderItemsId, result.Select(x => x.OrderItemsId));
                    Assert.Contains(res.ItemId, result.Select(x => x.ItemId));
                    Assert.Contains(res.ListPrice, result.Select(x => x.ListPrice));
                    Assert.Contains(res.Discount, result.Select(x => x.Discount));
                }
            }
        }
    }
}
