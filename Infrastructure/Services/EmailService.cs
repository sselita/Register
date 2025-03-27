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
        public async Task SendVerificationEmail(string email, string code)
        {
            string fromName = "";
            string fromEmail = "";
            string smtpHost = "smtp.example.com";
            int smtpPort = 587;
            string smtpUsername = "your_smtp_username";
            string smtpPassword = "your_smtp_password";

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

                // Send the email using SMTP with MailKit
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    // Connect to the SMTP server
                    client.Connect(smtpHost, smtpPort, true);  // 'true' indicates SSL/TLS
                    client.Authenticate(smtpUsername, smtpPassword);
                    client.Send(message);
                    client.Disconnect(true);  // Disconnect after sending the email
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
