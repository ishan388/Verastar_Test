using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using VS_DLRepositories.Orders;
using VS_Models;
using Xunit;

namespace VS_DLRepositories.Tests
{
    public class DLOrdersRepoTests
    {
        private IDLOrdersRepo dlRepo;
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
        [Fact]
        public void UploadBulkOrders_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(UploadBulkOrders_Test)))
            {
                dlRepo = new DLOrdersRepo(ctx);
                _ = dlRepo.UploadBulkOrders(orders);

                foreach (Order o in orders)
                {
                    Order? order = ctx.Orders.Where(e => e.Id == o.Id).FirstOrDefault();
                    order.Should().NotBeNull();
                    order.CustomerId.Should().Be(o.CustomerId);
                    order.Status.Should().Be(o.Status);
                    order.OrderDate.Should().Be(o.OrderDate);
                    order.RequiredDate.Should().Be(o.RequiredDate);
                    order.ShippedDate.Should().Be(o.ShippedDate);
                }
            }
        }

        [Fact]
        public void GetAllOrders_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(GetAllOrders_Test)))
            {
                dlRepo = new DLOrdersRepo(ctx);
                _ = dlRepo.UploadBulkOrders(orders);

                List<Order> result = dlRepo.GetAllOrders().Result;
                Assert.Equal(orders.Count, result.Count);

                foreach (Order o in result)
                {
                    Assert.Contains(o.Id, orders.Select(x => x.Id));
                    Assert.Contains(o.Status, orders.Select(x => x.Status));
                    Assert.Contains(o.CustomerId, orders.Select(x => x.CustomerId));
                    Assert.Contains(o.OrderDate, orders.Select(x => x.OrderDate));
                    Assert.Contains(o.RequiredDate, orders.Select(x => x.RequiredDate));
                    Assert.Contains(o.ShippedDate, orders.Select(x => x.ShippedDate));
                }
            }
        }

    }
}
