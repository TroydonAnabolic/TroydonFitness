using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.UserAccounts;

namespace TroydonFitnessWebsite.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

        Task SendWelcomeEmailAsync(WelcomeRequest request, string confirmAccountLink, string toEmail, string firstName);
        // TODO: Password reset email
        Task SendPasswordResetAsync(WelcomeRequest request, string confirmAccountLink, string toEmail, string firstName);

        Task UpdateEmailAsync(WelcomeRequest request, string confirmAccountLink, string toEmail, string firstName);

        Task SendRoutineOrderConfirmationEmail(WelcomeRequest request, string toEmail, string firstName,
            DateTime orderDate, Guid? orderNumber,
            string productName, decimal price, int quantity, PersonalTraining.SessionType sessionType, int lengthOfRoutine, PersonalTraining.Difficulty experienceLevel);
    }
}