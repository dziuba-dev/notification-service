using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Data;
using NotificationService.Dtos;
using NotificationService.Models;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private INotificationRepo _repo;
        private IMapper _mapper;

        public MailController(INotificationRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;
        }
        [HttpGet("{id}", Name = "GetMailById")]
        public ActionResult<GetMailDto> GetMailById(int id)
        {
            var MailItem = _repo.GetMailById(id);
            if (MailItem != null)
            {
                return Ok(_mapper.Map<GetMailDto>(MailItem));
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult<IEnumerable<GetMailDto>> GetMails()
        {
            Console.WriteLine("--> Getting Mail...");
            var MailItems = _repo.GetAllMail();
            if (MailItems != null) {
                return Ok(_mapper.Map<IEnumerable<GetMailDto>>(MailItems));
            }
            return NotFound();
        }
        /*
        [HttpPost]
        public ActionResult<GetMailDto> CreateMail(MailCreateDto mailCreateDto)
        {
            var mailModel = _mapper.Map<Email>(mailCreateDto);
            _repo.CreateEmail(mailModel);
            _repo.SaveChanges();
            var getMailDto=_mapper.Map<GetMailDto>(mailModel);
            return CreatedAtRoute(nameof(GetMailById), new { Id = getMailDto.Id }, getMailDto);
        }
        */
    }
}
