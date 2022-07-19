using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using VS_DLRepositories.OrderItems;
using VS_Models;
using Xunit;

namespace VS_DLRepositories.Tests
{
    public class DLOrderItemsRepoTests
    {
        private IDLOrderItemsRepo dlRepo;
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

        [Fact]
        public void UploadBulkOrderItems_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(UploadBulkOrderItems_Test)))
            {
                dlRepo = new DLOrderItemsRepo(ctx);
                _ = dlRepo.UploadBulkOrderItems(orderItems);

                foreach (OrderItem oi in orderItems)
                {
                    OrderItem? orderItem = ctx.OrderItems.Where(e => e.Id == oi.Id).FirstOrDefault();
                    orderItem.Should().NotBeNull();
                    orderItem.Discount.Should().Be(oi.Discount);
                    orderItem.ItemId.Should().Be(oi.ItemId);
                    orderItem.ListPrice.Should().Be(oi.ListPrice);
                    orderItem.OrderId.Should().Be(oi.OrderId);
                }
            }
        }

        [Fact]
        public void GetAllOrderItems_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(GetAllOrderItems_Test)))
            {
                dlRepo = new DLOrderItemsRepo(ctx);
                _ = dlRepo.UploadBulkOrderItems(orderItems);

                List<OrderItem> result = dlRepo.GetAllOrderItems().Result;
                Assert.Equal(orderItems.Count, result.Count);

                foreach (OrderItem oi in result)
                {
                    Assert.Contains(oi.Id, orderItems.Select(x => x.Id));
                    Assert.Contains(oi.Discount, orderItems.Select(x => x.Discount));
                    Assert.Contains(oi.ItemId, orderItems.Select(x => x.ItemId));
                    Assert.Contains(oi.ListPrice, orderItems.Select(x => x.ListPrice));
                    Assert.Contains(oi.OrderId, orderItems.Select(x => x.OrderId));
                }
            }

        }


        [Fact]
        public void UpdateBulkOrderItems_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(UpdateBulkOrderItems_Test)))
            {
                dlRepo = new DLOrderItemsRepo(ctx);
                _ = dlRepo.UploadBulkOrderItems(orderItems);

                orderItems = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        Id = 1,
                        Discount = 0.2m,
                        ItemId = 11,
                        ListPrice = 650m,
                        OrderId=5,
                    },
                    new OrderItem()
                    {
                        Id = 2,
                        Discount = 0.09m,
                        ItemId = 9,
                        ListPrice =999.99m,
                        OrderId=9,
                    }
                };

                _ = dlRepo.UpdateBulkOrderItems(orderItems);

                foreach (OrderItem oi in orderItems)
                {
                    OrderItem? orderItem = ctx.OrderItems.Where(e => e.Id == oi.Id).FirstOrDefault();
                    orderItem.Should().NotBeNull();
                    orderItem.Discount.Should().Be(oi.Discount);
                    orderItem.ItemId.Should().Be(oi.ItemId);
                    orderItem.ListPrice.Should().Be(oi.ListPrice);
                    orderItem.OrderId.Should().Be(oi.OrderId);
                }
            }
        }

    }
}
