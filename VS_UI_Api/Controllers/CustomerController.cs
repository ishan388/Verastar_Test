using Microsoft.AspNetCore.Mvc;
using VS_BLRepositories.Customers;
using VS_Models;

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

        [HttpPost]
        public async Task<IActionResult> Post(List<Customer> customers)
        {
            return Ok(await customersRepo.UploadBulkCustomers(customers).ConfigureAwait(false));
        }

    }
}
