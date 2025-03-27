using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SetPinDto
    {
        public string MobileNumber { get; set; }
        public string Pin { get; set; }
        public string ConfirmPin { get; set; }
    }
}
