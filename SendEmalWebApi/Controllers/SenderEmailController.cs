using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmalWebApi.Data;

namespace SendEmalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderEmailController : ControllerBase
    {
        private readonly SenderContext _context;
        public SenderEmailController(SenderContext context)
        {
            _context = context;
        }
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
