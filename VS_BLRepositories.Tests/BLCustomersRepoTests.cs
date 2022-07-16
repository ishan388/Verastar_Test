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
        Customer customer = new Customer()
        {
            Id = 1,
            Firstname = "Debra",
            Lastname = "Burks",
            Email = "debra.burks@yahoo.com",
            Street = "9273 Thorne Ave. ",
            City = "Orchard Park",
            State = "NY",
            ZipCode = "14127"
        };

        public BLCustomersRepoTests()
        {
            blRepo = new BLCustomersRepo(mockDLRepo.Object);
        }

        [Fact]
        public void UploadBulkCustomers_Test()
        {

        }

        [Fact]
        public void GetAllCustomers_Test()
        {
            List<Customer> expected = new List<Customer>();
            expected.Add(customer);
            expected.Add(new Customer()
            {
                Id = 2,
                Firstname = "Ishan",
                Lastname = "Malik",
                Email = "ishan388@yahoo.com",
                Street = "9273 Thorne Ave. ",
                City = "Orchard Park",
                State = "NY",
                ZipCode = "LS31AG"
            });

            mockDLRepo.Setup(svc => svc.GetAllCustomers()).ReturnsAsync(expected);
            List<Customer>? result = blRepo.GetAllCustomers().Result.DataList;
            Assert.Equal(expected.Count, result.Count);
            result.Should().BeEquivalentTo(expected);
            mockDLRepo.Verify(svc => svc.GetAllCustomers());
        }
    }
}