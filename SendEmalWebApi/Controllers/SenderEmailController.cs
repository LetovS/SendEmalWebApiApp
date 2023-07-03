using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SendEmalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderEmailController : ControllerBase
    {
        [HttpGet]
        [Route("/api/mails")]
        public async Task<ActionResult> GetProducts()
        {
            return default;
        }
        [HttpPost]
        [Route("/api/mails")]
        public async Task<ActionResult> GetProduct(int id)
        {
            return default;
        }
    }
}
