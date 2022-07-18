using FluentAssertions;
using Moq;
using System.Collections.Generic;
using VS_BLRepositories.Customers;
using VS_DLRepositories.Customers;
using VS_Models;
using Xunit;

namespace VS_BLRepositories.Tests
{
    public class BLCustomersRepoTests
    {
        private IBLCustomersRepo blRepo;
        private Mock<IDLCustomersRepo> mockDLRepo = new Mock<IDLCustomersRepo>();
        List<Customer> customers = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                Firstname = "Debra",
                Lastname = "Burks",
                Email = "debra.burks@yahoo.com",
                Street = "9273 Thorne Ave. ",
                City = "Orchard Park",
                State = "NY",
                ZipCode = "14127"
            },
            new Customer()
            {
                Id = 2,
                Firstname = "Ishan",
                Lastname = "Malik",
                Email = "ishan388@yahoo.com",
                Street = "9273 Thorne Ave. ",
                City = "Orchard Park",
                State = "NY",
                ZipCode = "LS31AG"
            }
        };

        public BLCustomersRepoTests()
        {
            blRepo = new BLCustomersRepo(mockDLRepo.Object);
        }

        [Fact]
        public void UploadBulkCustomers_Test()
        {
            mockDLRepo.Setup(svc => svc.UploadBulkCustomers(customers)).ReturnsAsync(customers.Count);
            int result = blRepo.UploadBulkCustomers(customers).Result.Data;
            Assert.Equal(customers.Count, result);
            mockDLRepo.Verify(svc => svc.UploadBulkCustomers(customers));
        }

        [Fact]
        public void GetAllCustomers_Test()
        {
            mockDLRepo.Setup(svc => svc.GetAllCustomers()).ReturnsAsync(customers);
            List<Customer>? result = blRepo.GetAllCustomers().Result.DataList;
            Assert.Equal(customers.Count, result.Count);
            result.Should().BeEquivalentTo(customers);
            mockDLRepo.Verify(svc => svc.GetAllCustomers());
        }
    }
}