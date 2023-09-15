using InstamojoAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentInstamojo.models;

namespace PaymentInstamojo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly InstamojoService instamojoService;

        public PaymentController(InstamojoService instamojoService)
        {
            this.instamojoService = instamojoService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaymentRequest(OrderRequest instamojo)
        {
            string paymentUrl = await instamojoService.CreatePaymentRequest(instamojo);

            if (paymentUrl != null)
            {
                return Ok(paymentUrl);
            }
            else
            {
                return BadRequest("Failed to create payment request");
            }
        }
    }
}
