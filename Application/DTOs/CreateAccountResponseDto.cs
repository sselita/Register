using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateAccountResponseDto
    {
        public object User { get; set; }
        public string MobileCode { get; set; }
        public string EmailCode { get; set; }
    }
}
