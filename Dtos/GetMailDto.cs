﻿using NotificationService.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NotificationService.Dtos
{
    public class GetMailDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
