using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
