using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ElasticEmailClient;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PartyMaker.Services
{
    public class EmailSender : IEmailSender
    {

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                Execute(email, subject, htmlMessage);
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Execute(string email, string subject, string message)
        {
            try
            {
                #if !DEBUG
                    var result = Api.Email.Send(subject, "partymaker@devsa.me", "Party Maker", bodyHtml: message, to: new[] { email });
                #endif
            }
            catch (Exception ex)
            {
                if (ex is ApplicationException)
                    Console.WriteLine("Server didn't accept the request: " + ex.Message);
                else
                    Console.WriteLine("Something unexpected happened: " + ex.Message);

            }
        }
    }
}