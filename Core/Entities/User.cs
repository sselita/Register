using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
    
            public Guid Id { get; set; }
            public string ICNumber { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }
            public bool IsMobileVerified { get; set; }
            public bool IsEmailVerified { get; set; }
           public string Pin { get; set; }
           public bool PrivacyPolicy { get; set; }

    }
}

