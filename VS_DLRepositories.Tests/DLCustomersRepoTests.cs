using System.Collections.Generic;
using System.Linq;
using VS_DLRepositories.Customers;
using VS_Models;
using Xunit;

namespace VS_DLRepositories.Tests
{
    public class DLCustomersRepoTests
    {
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
        private DLCustomersRepo dlRepo;

        [Fact]
        public void UploadBulkCustomers_Test()
        {

        }

        [Fact]
        public void GetAllCustomers_Test()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            customers.Add(new Customer()
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

            using (var ctx = DbContextFactory.Create(nameof(GetAllCustomers_Test)))
            {
                dlRepo = new DLCustomersRepo(ctx);
                foreach (Customer cust in customers)
                {
                    cust.Id = dlRepo.AddCustomer(cust).Result;
                }

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