﻿using NotificationService.Models;

namespace NotificationService.Dtos
{
    public class SendMailDto
    {
        public int EmailId { get; set; }
        public int UserId { get; set; }
        public int AdminId {  get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
