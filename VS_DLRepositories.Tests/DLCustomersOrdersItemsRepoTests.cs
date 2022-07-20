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
                State= "CA",
                OrderId= 1084,
                TotalDiscount=361.2853m,
                TotalListPrice=4056.95m
            },
            new VM_CustomersOrdersItems()
            {
                CustomerId= 1,
                Fullname= "Debra Burks",
                Email= "debra.burks@yahoo.com",
                State= "NY",
                OrderId= 599,
                TotalDiscount=379.8968m,
                TotalListPrice=5118.97m
            }
        };

        [Fact]
        public void GetAllCustomers1_Test()
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
                    Assert.Contains(res.State, result.Select(x => x.State));
                    Assert.Contains(res.OrderId, result.Select(x => x.OrderId));
                    Assert.Contains(res.TotalDiscount, result.Select(x => x.TotalDiscount));
                    Assert.Contains(res.TotalListPrice, result.Select(x => x.TotalListPrice));
                    Assert.Contains(res.FinalPrice, result.Select(x => x.FinalPrice));
                }
            }
        }


    }
}
