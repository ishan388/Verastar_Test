using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VS_DLRepositories.Customers;
using VS_Models;
using Xunit;

namespace VS_DLRepositories.Tests
{
    public class DLCustomersRepoTests
    {
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
        private IDLCustomersRepo dlRepo;

        [Fact]
        public void UploadBulkCustomers_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(UploadBulkCustomers_Test)))
            {
                dlRepo = new DLCustomersRepo(ctx);
                _ = dlRepo.UploadBulkCustomers(customers);

                foreach (Customer cust in customers)
                {
                    Customer? customer = ctx.Customers.Where(e => e.Email.ToLower() == cust.Email.ToLower()).FirstOrDefault();
                    customer.Should().NotBeNull();

                    Assert.Equal(cust.Firstname, customer.Firstname);
                    Assert.Equal(cust.Lastname, customer.Lastname);
                    Assert.Equal(cust.Email, customer.Email);
                    Assert.Equal(cust.Street, customer.Street);
                    Assert.Equal(cust.City, customer.City);
                    Assert.Equal(cust.State, customer.State);
                    Assert.Equal(cust.ZipCode, customer.ZipCode);
                }
            }
        }

        [Fact]
        public void GetAllCustomers_Test()
        {
            using (var ctx = DbContextFactory.Create(nameof(GetAllCustomers_Test)))
            {
                dlRepo = new DLCustomersRepo(ctx);
                _ = dlRepo.UploadBulkCustomers(customers);

                List<Customer> result = dlRepo.GetAllCustomers().Result;
                Assert.Equal(customers.Count, result.Count);

                foreach (Customer cust in result)
                {
                    Assert.Contains(cust.Id, customers.Select(x => x.Id));
                    Assert.Contains(cust.Firstname, customers.Select(x => x.Firstname));
                    Assert.Contains(cust.Lastname, customers.Select(x => x.Lastname));
                    Assert.Contains(cust.Email, customers.Select(x => x.Email));
                    Assert.Contains(cust.Street, customers.Select(x => x.Street));
                    Assert.Contains(cust.City, customers.Select(x => x.City));
                    Assert.Contains(cust.State, customers.Select(x => x.State));
                    Assert.Contains(cust.ZipCode, customers.Select(x => x.ZipCode));
                }
            }

        }

    }
}