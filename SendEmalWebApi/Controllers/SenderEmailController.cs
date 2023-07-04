using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendEmalWebApi.Data;
using SendEmalWebApi.Model;
using SendEmalWebApi.Repositories;
using SendEmalWebApi.Services.EmailSenderService;

namespace SendEmalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderEmailController : ControllerBase
    {
        private readonly IRepository<EntityDB> _baseRepository;
        private readonly IEmailSenderService _senderService;

        public SenderEmailController(IRepository<EntityDB> baseRepository, IEmailSenderService senderService)
        {
            _baseRepository = baseRepository;
            _senderService = senderService;
        }
        [HttpGet]
        [Route("/api/mails")]
        public async Task<ActionResult<List<EntityDB>>> GetProducts()
        { 
            return await _baseRepository.GetAll();
        }
        [HttpPost]
        [Route("/api/mails")]
        public async Task<ActionResult> NewWork(RequestModel model)
        {
            var entity = new EntityDB();
            // Сформеровать email  model.Subject model.Body


            try
            {
                // разослать по  model.Recipients

                entity.Result = "OK";
            }
            catch (Exception e)
            {
                entity.Result = "Failed";
                entity.FieledMessage = e.Message;
            }

            // записать в бд 

            entity.CreatedDate = DateTime.Now.Date;
            entity.Subject = model.Subject;
            entity.Body = model.Body;
            List<Email> emails = new List<Email>();
            foreach (var email in model.Recipient)
            {
                emails.Add(new Email { EmailAddress = email });
            }
            entity.Recipient = emails;
            //_context.RequestModels.Add(entity);
            //_context.SaveChanges();
            return Ok();
        }
    }
}
