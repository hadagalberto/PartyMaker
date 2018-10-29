using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PartyMaker.Services
{
    public class EmailSender : IEmailSender
    {

        private readonly string SendGridAPIKey =
            "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";

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                Execute(email, subject, htmlMessage).Wait();
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Execute(string email, string subject, string message)
        {
            var client = new SendGridClient(SendGridAPIKey);
            var from = new EmailAddress("partymaker@devsa.me", "Party Maker");
            var to = new EmailAddress(email, "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}