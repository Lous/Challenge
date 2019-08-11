using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.WebApi.Models.Response
{
    public class PhoneResponse
    {
        public string CountryCode { get; set; }

        public int Number { get; set; }

        public int AreaCode { get; set; }
    }
}
