using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.Identity.Client;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        public async Task SendVerificationSms(string mobileNumber, string code)
        {
            var accountSid ="12345";
            var authToken = "12345";
            var from = "04304035";
            try
            {
                // Initialize Twilio Client with provided credentials
                TwilioClient.Init(accountSid, authToken);

              

                // Send the SMS with the verification code
                var message = MessageResource.Create(
                    body: $"Your verification code is: {code}",
                    from: from,
                    to:mobileNumber
                );

         
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending SMS: {ex.Message}");
            }
        }
    }
}
    

