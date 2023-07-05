using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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
        private readonly IRepository<Log> _baseRepository;
        private readonly IEmailSenderService _senderService;

        public SenderEmailController(IRepository<Log> baseRepository, IEmailSenderService senderService)
        {
            _baseRepository = baseRepository;
            _senderService = senderService;
        }
        [HttpGet]
        [Route("/api/mails")]
        public async Task<ActionResult<List<Log>>> GetProducts()
        { 
            return await _baseRepository.GetAll();
        }
        [HttpPost]
        [Route("/api/mails")]
        public async Task<ActionResult> NewWork(RequestModel model)
        {
            var entity = new Log();
            // Сформеровать email  model.Subject model.Body


            try
            {
                // разослать по  model.Recipients
                _senderService.SendEmail(model.Recipient!, model.Body!, model.Subject!);
                entity.Result = "OK";
            }
            catch (Exception e)
            {
                entity.Result = "Failed";
                entity.FieledMessage = e.Message;
            }

            // записать в бд 
            entity.Subject = model.Subject;
            entity.Body = model.Body;
            List<Email> emails = new ();
            foreach (var email in model.Recipient!)
            {
                emails.Add(new Email { EmailAddress = email });
            }
            entity.Recipient = emails;
            await _baseRepository.Create(entity);
            return Ok();
        }
    }
}
