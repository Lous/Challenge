using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Models
{
    public class PhoneViewModel
    {
        public string CountryCode { get; set; }

        public int Number { get; set; }

        public int AreaCode { get; set; }
    }
}
