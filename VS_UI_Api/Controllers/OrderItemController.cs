using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VS_BLRepositories.OrderItems;
using VS_Models;

namespace VS_UI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private IBLOrderItemsRepo orderItemsRepo;

        public OrderItemController(IBLOrderItemsRepo _orderItemsRepo)
        {
            orderItemsRepo = _orderItemsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await orderItemsRepo.GetAllOrderItems().ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<OrderItem> orderItems)
        {
            return Ok(await orderItemsRepo.UploadBulkOrderItems(orderItems).ConfigureAwait(false));
        }

    }
}
