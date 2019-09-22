using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Models
{
    public class UserViewModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}
