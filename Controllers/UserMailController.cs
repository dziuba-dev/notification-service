using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Data;
using NotificationService.Dtos;
using NotificationService.Models;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMailController : ControllerBase
    {
        private INotificationRepo _repo;
        private IMapper _mapper;

        public UserMailController(INotificationRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;
        }
        [HttpGet("{id}", Name = "GetMailById")]
        public ActionResult<GetMailDto> GetMailById(int id)
        {
            var uMailItem = _repo.GetMailById(id);
            if (uMailItem != null)
            {
                return Ok(_mapper.Map<GetMailDto>(uMailItem));
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult<IEnumerable<GetMailDto>> GetUserMails()
        {
            Console.WriteLine("--> Getting UserMail...");
            var uMailItems = _repo.GetAllUserEmail();
            if (uMailItems != null) {
                return Ok(_mapper.Map<IEnumerable<GetMailDto>>(uMailItems));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<GetMailDto> CreateUserMail(UserMailCreateDto userMailCreateDto)
        {
            var mailModel = _mapper.Map<EmailToUser>(userMailCreateDto);
            AdminMailCreateDto admin=new AdminMailCreateDto("bar1walc@gmail.com","Users Message was: '"+mailModel.Message+"'",(Models.UserType)1);
            var aMailModel = _mapper.Map<EmailToAdmin>(admin);
            _repo.CreateEmail(mailModel,aMailModel);
            _repo.SaveChanges();
            var getMailDto=_mapper.Map<GetMailDto>(mailModel);
            return CreatedAtRoute(nameof(GetMailById), new { Id = getMailDto.Id }, getMailDto);
        }
    }
}
