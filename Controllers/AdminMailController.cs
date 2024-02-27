using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Data;
using NotificationService.Dtos;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMailController : ControllerBase
    {
        private INotificationRepo _repo;
        private IMapper _mapper;
        public AdminMailController(INotificationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetAdminMailById")]
        public ActionResult<GetMailDto> GetAdminMailById(int id)
        {
            var aMailItem = _repo.GetAdminMailById(id);
            if (aMailItem != null)
            {
                return Ok(_mapper.Map<GetAdminMailDto>(aMailItem));
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult<IEnumerable<GetAdminMailDto>> GetAdminMails()
        {
            Console.WriteLine("--> Getting AdminMail...");
            var aMailItems = _repo.GetAllAdminEmail();
            if (aMailItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<GetAdminMailDto>>(aMailItems));
            }
            return NotFound();
        }
    }
    
}
