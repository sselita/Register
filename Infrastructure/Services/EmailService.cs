using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MimeKit;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        //Email > Go to Security > Advanced Security Options.
        //Enable Two-Step Verification(if not already enabled).

        //Generate an app password for your application.
        //SMTP Username and Password:
        //SMTP Username: Your Outlook email address (e.g., your_email @outlook.com or your_email @yourdomain.com).
        //SMTP Password: The app password you generated or your account password(if 2FA is not enabled).

        public async Task SendVerificationEmail(string email, string code)
        {
            string fromName = "Stiv";
            string fromEmail = "selitastiv@gmail.com";
            string smtpHost = "smtp.office365.com";
            int smtpPort = 587;
            string smtpUsername = "selitastiv";
            string smtpPassword = "password";

            try
            {


                // Create the email message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromName, fromEmail));
                message.To.Add(new MailboxAddress(fromName, email));
                message.Subject = "Your Verification Code";

                // Build the email body with the verification code
                var body = new TextPart()
                {
                    Text = $"Your verification code is: {code}"
                };

                message.Body = body;

                // Send the email 
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    // Connect to the SMTP server
                    client.Connect(smtpHost, smtpPort, true);
                    client.Authenticate(smtpUsername, smtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }

                // Optionally log that the message was sent
                Console.WriteLine($"Verification email sent to {email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
