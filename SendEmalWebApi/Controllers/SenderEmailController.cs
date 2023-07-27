using Microsoft.AspNetCore.Mvc;
using SendEmalWebApi.Model;
using SendEmalWebApi.Repositories;
using SendEmalWebApi.Services.EmailSenderService;

namespace SendEmalWebApi.Controllers
{
    /// <summary>
    /// Контроллер логов.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SenderEmailController : ControllerBase
    {
        private readonly IRepository<Log> _baseRepository;
        private readonly IEmailSenderService _senderService;
        /// <summary>
        /// Инициализация контроллера.
        /// </summary>
        /// <param name="baseRepository">Репозиторий для работы с бд.</param>
        /// <param name="senderService">Сервис отправки электронной почты.</param>
        public SenderEmailController(IRepository<Log> baseRepository, IEmailSenderService senderService)
        {
            _baseRepository = baseRepository;
            _senderService = senderService;
        }
        /// <summary>
        /// Получение всех логов.
        /// </summary>
        /// <returns>Логи.</returns>
        [HttpGet]
        [Route("/api/mails")]
        public async Task<ActionResult<List<Log>>> GetLogs()
        { 
            return await _baseRepository.GetAll();
        }
        /// <summary>
        /// Добавление нового лога.
        /// </summary>
        /// <param name="request">Данные входящего запроса.</param>
        [HttpPost]
        [Route("/api/mails")]
        public async Task<ActionResult> AddLog(Request request)
        {
            var log = new Log();
            // Сформеровать email  request.Subject request.Body
            try
            {
                // разослать по  request.Recipients
                await _senderService.SendEmailAsync(request.Recipient!, request.Body!, request.Subject!);
                log.Result = "OK";
            }
            catch (Exception e)
            {
                log.Result = "Failed";
                log.FieledMessage = e.Message;
            }

            // записать в бд 
            SetValuesForNewLog(request, log);
            await _baseRepository.Add(log);
            return Ok();
        }

        private static void SetValuesForNewLog(Request request, Log entity)
        {
            entity.Subject = request.Subject;
            entity.Body = request.Body;
            List<Email> emails = new();
            foreach (var email in request.Recipient!)
            {
                emails.Add(new Email { EmailAddress = email });
            }
            entity.Recipient = emails;
        }
    }
}
