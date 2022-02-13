using System;
using System.Collections.Generic;
using System.Text;

namespace Shipmanagement.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
