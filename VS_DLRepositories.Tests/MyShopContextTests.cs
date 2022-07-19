using System.Linq;
using VS_Models;
using Xunit;

namespace VS_DLRepositories.Tests
{
    public class MyShopContextTests
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

        [Fact]
        public void AddCustomerToMemoryDb()
        {
            using (var ctx = DbContextFactory.Create(nameof(AddCustomerToMemoryDb)))
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();

                Customer? savedCustomer = ctx.Customers.Where(e => e.Id == customer.Id).SingleOrDefault();
                Assert.Equal(customer.Firstname, savedCustomer.Firstname);
                Assert.Equal(customer.Lastname, savedCustomer.Lastname);
                Assert.Equal(customer.Email, savedCustomer.Email);
                Assert.Equal(customer.Street, savedCustomer.Street);
                Assert.Equal(customer.City, savedCustomer.City);
                Assert.Equal(customer.State, savedCustomer.State);
                Assert.Equal(customer.ZipCode, savedCustomer.ZipCode);
            }
        }
    }
}
