using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Phones = new HashSet<Phone>();
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime LastAccess { get; set; } = DateTime.UtcNow;

        public IEnumerable<Phone> Phones { get; set; }
    }
}
