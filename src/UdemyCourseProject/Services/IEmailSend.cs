﻿using System.Threading.Tasks;

namespace UdemyCourseProject.Services
{
    public interface IEmailSend
    {
       Task SendEmailAsync(string email, string subject, string message);
    }
}
