using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public int Number { get; set; }

        public int AreaCode { get; set; }

        public string CountryCode { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
