using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Data;
using SendEmalWebApi.Model;

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
        public async Task<ActionResult<List<EntityDB>>> GetProducts()
        {

            // получить все запси 
            var result = await _context.RequestModels.Include(x => x.Recipient).ToListAsync();

            return result;
        }
        [HttpPost]
        [Route("/api/mails")]
        public async Task<ActionResult<RequestModel>> NewWork(RequestModel model)
        {

            // Сформеровать email  model.Subject model.Body

            // разослать по  model.Recipients
            // 

            // записать в бд 
            
            return default;
        }
    }
}
