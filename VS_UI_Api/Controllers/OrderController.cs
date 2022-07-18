using Microsoft.AspNetCore.Mvc;
using VS_BLRepositories.Orders;
using VS_Models;

namespace VS_UI_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IBLOrdersRepo ordersRepo;

        public OrderController(IBLOrdersRepo _ordersRepo)
        {
            ordersRepo = _ordersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await ordersRepo.GetAllOrders().ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<Order> orders)
        {
            return Ok(await ordersRepo.UploadBulkOrders(orders).ConfigureAwait(false));
        }
    }
}
