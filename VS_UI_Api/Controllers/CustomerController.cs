using Microsoft.AspNetCore.Mvc;
using VS_BLRepositories.Customers;

namespace VS_UI_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private IBLCustomersRepo customersRepo;

        public CustomerController(IBLCustomersRepo _customersRepo)
        {
            customersRepo = _customersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customersRepo.GetAllCustomers().ConfigureAwait(false));
        }

    }
}
