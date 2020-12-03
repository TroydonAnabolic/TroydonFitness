using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.UserAccounts;
using TroydonFitnessWebsite.Settings.Mail;

namespace TroydonFitnessWebsite.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;
            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }
            message.IsBodyHtml = false;
            message.Body = mailRequest.Body;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task SendWelcomeEmailAsync(WelcomeRequest request, string confirmAccountLink, string toEmail, string firstName)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Areas\\Identity\\Pages\\Account\\EmailTemplates\\RegistrationConfirmationEmail.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            // below line replaces all the html content inside the WelcomeEmail.cshtml, using Replace.[whatever is inside this], isReplacedWithThis
            MailText = MailText.Replace("[firstname]", firstName).Replace("[email]", toEmail).Replace("[confirm account link]", confirmAccountLink);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = $"Please confirm your email {firstName}";
            message.IsBodyHtml = true;
            message.Body = MailText;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task SendRoutineOrderConfirmationEmail(WelcomeRequest request, string toEmail, string firstName,
            DateTime orderDate, Guid? orderNumber,
            string productName, decimal price, int quantity, PersonalTraining.SessionType sessionType, int lengthOfRoutine, PersonalTraining.Difficulty experienceLevel)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Areas\\Identity\\Pages\\Account\\EmailTemplates\\OrderConfirmation.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            // below line replaces all the html content inside the WelcomeEmail.cshtml, using Replace.[whatever is inside this], isReplacedWithThis
            MailText = MailText.Replace("[firstname]", firstName).Replace("[email]", toEmail).Replace("[orderdate]", orderDate.ToString())
                .Replace("[ordernumber]", orderNumber.ToString()).Replace("[productname]", productName).Replace("[price]", price.ToString())
                .Replace("[quantity]", quantity.ToString()).Replace("[sessiontype]", sessionType.ToString()).Replace("[lengthofroutine]",
                lengthOfRoutine.ToString()).Replace("[experiencelevel]", experienceLevel.ToString()); // Finish later
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = $"TroydonFitness - Order Confirmation {firstName}";
            message.IsBodyHtml = true;
            message.Body = MailText;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task SendPasswordResetAsync(WelcomeRequest request, string resetPassLink, string toEmail, string firstName)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Areas\\Identity\\Pages\\Account\\EmailTemplates\\ResetPasswordEmail.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            // below line replaces all the html content inside the WelcomeEmail.cshtml, using Replace.[whatever is inside this], isReplacedWithThis
            MailText = MailText.Replace("[firstname]", firstName).Replace("[email]", toEmail).Replace("[reset pass link]", resetPassLink);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = $"Please confirm your email {firstName}";
            message.IsBodyHtml = true;
            message.Body = MailText;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task UpdateEmailAsync(WelcomeRequest request, string updateEmailLink, string toEmail, string firstName)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Areas\\Identity\\Pages\\Account\\EmailTemplates\\UpdateEmail.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            // below line replaces all the html content inside the WelcomeEmail.cshtml, using Replace.[whatever is inside this], isReplacedWithThis
            MailText = MailText.Replace("[firstname]", firstName).Replace("[email]", toEmail).Replace("[update email link]", updateEmailLink);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = $"Please confirm your new email {firstName}";
            message.IsBodyHtml = true;
            message.Body = MailText;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}