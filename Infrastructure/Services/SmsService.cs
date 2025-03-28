using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using Twilio;
using Twilio.Jwt.AccessToken;
using Twilio.Rest.Api.V2010.Account;

namespace Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        // Go to the Twilio website.

        //Create an account(or log in if you already have one).

        //Retrieve your:
        //Account SID
        //Auth Token
        //Twilio Phone Number These are available in your Twilio dashboard.

        //3. Replace Placeholder Values
        //Update the method with your Twilio credentials:
        //Replace accountSid with your actual Account SID.
        //Replace authToken with your Auth Token.
        //Replace +from with your Twilio phone number (in E.164 format).

        public async Task SendVerificationSms(string mobileNumber, string code)
        {
            var accountSid = "00856589";
            var authToken = "f1c64b19-1cf1-451b-a36f-d88cffdbd74c";
            var from = "00355682017197";
            try
            {
                // Initialize Twilio Client with provided credentials
                TwilioClient.Init(accountSid, authToken);



                // Send the SMS with the verification code
                var message = MessageResource.Create(
                    body: $"Your verification code is: {code}",
                    from: from,
                    to: mobileNumber
                );


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending SMS: {ex.Message}");
            }
        }
    }
}


