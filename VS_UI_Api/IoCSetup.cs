using VS_BLRepositories.Customers;
using VS_BLRepositories.OrderItems;
using VS_BLRepositories.Orders;
using VS_DLRepositories.Customers;
using VS_DLRepositories.OrderItems;
using VS_DLRepositories.Orders;

namespace VS_UI_Api
{
    public class IoCSetup
    {
        internal static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDLCustomersRepo, DLCustomersRepo>();
            builder.Services.AddScoped<IBLCustomersRepo, BLCustomersRepo>();
            builder.Services.AddScoped<IDLOrdersRepo, DLOrdersRepo>();
            builder.Services.AddScoped<IBLOrdersRepo, BLOrdersRepo>();
            builder.Services.AddScoped<IDLOrderItemsRepo, DLOrderItemsRepo>();
            builder.Services.AddScoped<IBLOrderItemsRepo, BLOrderItemsRepo>();
        }
    }
}
