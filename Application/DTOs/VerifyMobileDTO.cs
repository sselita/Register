using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VerifyMobileDto
    {
        public string IcNumber { get; set; }
        public string Code { get; set; }
        public string MobileVerificationCode { get; set; }
    }
}
