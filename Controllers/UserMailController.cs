using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Data;
using NotificationService.Dtos;

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
        [HttpGet]
        public ActionResult<IEnumerable<GetMailDto>> GetUserMails()
        {
            Console.WriteLine("--> Getting UserMail...");
            var uMailItems=_repo.GetAllUserEmail();
            return Ok(_mapper.Map<IEnumerable<GetMailDto>>(uMailItems));
        }
    }
}
