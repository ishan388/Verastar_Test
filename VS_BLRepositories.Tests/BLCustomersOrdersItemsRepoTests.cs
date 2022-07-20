using FluentAssertions;
using Moq;
using System.Collections.Generic;
using VS_BLRepositories.CustomersOrdersItems;
using VS_DLRepositories.CustomersOrdersItems;
using VS_Models.ViewModels;
using Xunit;

namespace VS_BLRepositories.Tests
{
    public class BLCustomersOrdersItemsRepoTests
    {
        private IBLCustomersOrdersItemsRepo blRepo;
        private Mock<IDLCustomersOrdersItemsRepo> mockDLRepo = new Mock<IDLCustomersOrdersItemsRepo>();
        
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

        public BLCustomersOrdersItemsRepoTests()
        {
            blRepo = new BLCustomersOrdersItemsRepo(mockDLRepo.Object);
        }

        [Fact]
        public void GetAllData_Test()
        {
            mockDLRepo.Setup(svc => svc.GetAllData()).ReturnsAsync(data);
            List<VM_CustomersOrdersItems>? result = blRepo.GetAllData().Result.DataList;
            Assert.Equal(data.Count, result.Count);
            result.Should().BeEquivalentTo(data);
            mockDLRepo.Verify(svc => svc.GetAllData());
        }

    }
}
