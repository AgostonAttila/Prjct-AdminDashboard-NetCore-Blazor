using Application.DTOs.Email;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace SharedCore.Services
{
    public class EmailService : IEmailService
    {
        public MailSettings _mailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
    }
}

    //    public async Task SendEmailWithAttachmentAsync(MailRequest mailRequest)
    //    {
    //        var email = new MimeMessage();
    //        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
    //        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
    //        email.Subject = mailRequest.Subject;
    //        var builder = new BodyBuilder();
    //        if (mailRequest.Attachments != null)
    //        {
    //            byte[] fileBytes;
    //            foreach (var file in mailRequest.Attachments)
    //            {
    //                if (file.Length > 0)
    //                {
    //                    using (var ms = new MemoryStream())
    //                    {
    //                        file.CopyTo(ms);
    //                        fileBytes = ms.ToArray();
    //                    }
    //                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
    //                }
    //            }
    //        }
    //        builder.HtmlBody = mailRequest.Body;
    //        email.Body = builder.ToMessageBody();
    //        using var smtp = new SmtpClient();
    //        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
    //        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
    //        await smtp.SendAsync(email);
    //        smtp.Disconnect(true);
    //    }
    //}
//}
