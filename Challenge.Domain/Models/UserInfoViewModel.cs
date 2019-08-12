using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Models
{
    public class UserInfoViewModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public IEnumerable<PhoneViewModel> Phones { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastAccess { get; set; }
    }
}
