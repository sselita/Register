using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VerifyEmailDto
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
