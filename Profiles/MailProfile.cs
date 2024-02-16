using AutoMapper;
using NotificationService.Dtos;
using NotificationService.Models;

namespace NotificationService.Profiles
{
    public class MailProfile :Profile
    {
        public MailProfile()
        {
            CreateMap<EmailToUser, GetMailDto>();
            CreateMap<UserMailCreateDto, EmailToUser>();
        }
    }
}
