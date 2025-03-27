using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class MobileVerification
    {
        public string MobileNumber { get; set; } // Mobile number to verify
        public string VerificationCode { get; set; } // Verification code sent to the mobile number
    }
}
