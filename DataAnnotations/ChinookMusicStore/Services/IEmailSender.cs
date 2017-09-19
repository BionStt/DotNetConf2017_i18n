﻿using System.Threading.Tasks;

namespace ChinookMusicStore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
