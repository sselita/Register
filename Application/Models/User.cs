using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public string IcNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public bool IsMobileVerified { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
