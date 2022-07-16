﻿using Microsoft.EntityFrameworkCore;
using VS_Models;

namespace VS_DLRepositories.Customers
{
    public class DLCustomersRepo : IDLCustomersRepo
    {
        private MyShopContext dbCtx;

        public DLCustomersRepo(MyShopContext ctx)
        {
            dbCtx = ctx;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await dbCtx.Customers.ToListAsync();
        }

        public Task<int> UploadBulkCustomers(List<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            Customer newCustomer = customer;
            await dbCtx.Customers.AddAsync(newCustomer);
            await dbCtx.SaveChangesAsync();
            return newCustomer.Id;
        }
    }
}