using FluentAssertions;
using Moq;
using System.Collections.Generic;
using VS_BLRepositories.Orders;
using VS_DLRepositories.Orders;
using VS_Models;
using Xunit;

namespace VS_BLRepositories.Tests
{
    public class BLOrdersRepoTests
    {
        private IBLOrdersRepo blRepo;
        private Mock<IDLOrdersRepo> mockDLRepo = new Mock<IDLOrdersRepo>();
        List<Order> orders = new List<Order>()
        {
            new Order()
            {
                Id = 76,
                CustomerId = 9,
                Status = 3,
                OrderDate = new System.DateTime(2016,2,16),
                RequiredDate = new System.DateTime(2016,2,16),
                ShippedDate=null
            },
            new Order()
            {
                Id = 104,
                CustomerId = 7,
                Status = 4,
                OrderDate = new System.DateTime(2016,3,3),
                RequiredDate = new System.DateTime(2016,3,3),
                ShippedDate=new System.DateTime(2016,3,5),
            }
        };

        public BLOrdersRepoTests()
        {
            blRepo = new BLOrdersRepo(mockDLRepo.Object);
        }

        [Fact]
        public void UploadBulkOrders_Test()
        {
            mockDLRepo.Setup(svc => svc.UploadBulkOrders(orders)).ReturnsAsync(orders.Count);
            int result = blRepo.UploadBulkOrders(orders).Result.Data;
            Assert.Equal(orders.Count, result);
            mockDLRepo.Verify(svc => svc.UploadBulkOrders(orders));
        }

        [Fact]
        public void GetAllOrders_Test()
        {
            mockDLRepo.Setup(svc => svc.GetAllOrders()).ReturnsAsync(orders);
            List<Order>? result = blRepo.GetAllOrders().Result.DataList;
            Assert.Equal(orders.Count, result.Count);
            result.Should().BeEquivalentTo(orders);
            mockDLRepo.Verify(svc => svc.GetAllOrders());
        }

    }
}
