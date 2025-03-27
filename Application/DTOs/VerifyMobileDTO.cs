using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VerifyMobileDto
    {
        public string MobileNumber { get; set; }
        public string VerificationCode { get; set; }
    }
}
