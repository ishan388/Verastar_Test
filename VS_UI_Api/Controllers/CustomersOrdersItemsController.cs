using Microsoft.AspNetCore.Mvc;
using VS_BLRepositories.CustomersOrdersItems;

namespace VS_UI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersOrdersItemsController : ControllerBase
    {
        private IBLCustomersOrdersItemsRepo blRepo;

        public CustomersOrdersItemsController(IBLCustomersOrdersItemsRepo _blRepo)
        {
            blRepo = _blRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await blRepo.GetAllData1().ConfigureAwait(false));
        }

    }
}
