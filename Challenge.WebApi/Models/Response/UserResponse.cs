using Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.WebApi.Models.Response
{
    public class UserResponse
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public IEnumerable<PhoneResponse> Phones { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime LastAccess { get; set; }
    }
}
