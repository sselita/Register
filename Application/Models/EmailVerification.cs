using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EmailVerification
    {
        public string Email { get; set; } // Email to verify
        public string VerificationCode { get; set; } // Verification code sent to the email
    }
}
