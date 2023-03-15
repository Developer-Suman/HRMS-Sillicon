using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Helper
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        public AuthMessageSenderOptions Options { get; }
        public EmailSender(IOptions<AuthMessageSenderOptions> OptionsAcces, ILogger<EmailSender> logger)
        {
            Options = OptionsAcces.Value;
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        private async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("siliconsoftnepal@gmail.com", "Silicon Soft and I.T. Consultant Pvt. Ltd."),
                Subject = subject,
                //PlainTextContent = message
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email)); 

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            var res = await client.SendEmailAsync(msg);
            res = res;

            _logger.LogInformation(res.IsSuccessStatusCode
                              ? $"Email to {email} queued successfully!"
                              : $"Failure Email to {email}");
        }
    }
}
