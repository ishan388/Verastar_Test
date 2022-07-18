using FluentAssertions;
using Moq;
using System.Collections.Generic;
using VS_BLRepositories.OrderItems;
using VS_DLRepositories.OrderItems;
using VS_Models;
using Xunit;

namespace VS_BLRepositories.Tests
{
    public class BLOrderItemsRepoTests
    {
        private IBLOrderItemsRepo blRepo;
        private Mock<IDLOrderItemsRepo> mockDLRepo = new Mock<IDLOrderItemsRepo>();
        List<OrderItem> orderItems = new List<OrderItem>()
        {
            new OrderItem()
            {
                Id = 1,
                Discount =0.1m,
                ItemId = 1,
                ListPrice =549.99m,
                OrderId=1,
            },
            new OrderItem()
            {
                Id = 2,
                Discount =0.05m,
                ItemId = 2,
                ListPrice =1680.99m,
                OrderId=1,
            }
        };
        public BLOrderItemsRepoTests()
        {
            blRepo = new BLOrderItemsRepo(mockDLRepo.Object);
        }

        [Fact]
        public void UploadBulkOrderItems_Test()
        {
            mockDLRepo.Setup(svc => svc.UploadBulkOrderItems(orderItems)).ReturnsAsync(orderItems.Count);
            int result = blRepo.UploadBulkOrderItems(orderItems).Result.Data;
            Assert.Equal(orderItems.Count, result);
            mockDLRepo.Verify(svc => svc.UploadBulkOrderItems(orderItems));
        }

        [Fact]
        public void GetAllOrderItems_Test()
        {
            mockDLRepo.Setup(svc => svc.GetAllOrderItems()).ReturnsAsync(orderItems);
            List<OrderItem>? result = blRepo.GetAllOrderItems().Result.DataList;
            Assert.Equal(orderItems.Count, result.Count);
            result.Should().BeEquivalentTo(orderItems);
            mockDLRepo.Verify(svc => svc.GetAllOrderItems());
        }

    }
}
