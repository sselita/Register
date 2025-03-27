using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateAccountDto
    {
        public string ICNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
