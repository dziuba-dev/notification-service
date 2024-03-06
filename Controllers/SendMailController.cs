using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Data;
using NotificationService.Dtos;
using NotificationService.Models;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {

        private INotificationRepo _repo;
        private IMapper _mapper;


        public SendMailController(INotificationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost]
        public string SendMail(SendMailDto sendMailDto)
        {
            Email email = _repo.CreateEmail(new Email(sendMailDto.Subject, sendMailDto.Message));
            User user=_repo.GetUserById(sendMailDto.UserId);
            User admin=_repo.GetUserById(sendMailDto.AdminId);
            if(admin.UserType != UserType.Admin)  throw new Exception("admin must be an admin");
            _repo.SendMail(email,user,admin);
            return "Mail sent, Message: "+email.Message;
        }
    }
}
