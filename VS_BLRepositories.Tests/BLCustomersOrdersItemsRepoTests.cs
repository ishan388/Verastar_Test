using FluentAssertions;
using Moq;
using System;
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
