using Challenge.Domain.Entities;
using Challenge.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.WebApi.Models.Request
{
    public class SignUpRequest
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}
