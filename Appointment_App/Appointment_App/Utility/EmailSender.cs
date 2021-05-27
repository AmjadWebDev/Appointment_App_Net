using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_App.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("5164877d2c64b90fd7b6b41c93340950", "41e60fe07ae470421717ad6731bb461b")
            {

            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
           .Property(Send.FromEmail, "amjadwebdev@gmail.com")
           .Property(Send.FromName, "Appointment Scheduler")
           .Property(Send.Subject, subject)
           .Property(Send.HtmlPart, htmlMessage)
           .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", email}
                 }
               });
            MailjetResponse response = await client.PostAsync(request);


        }
    }
}
