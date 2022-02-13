using System;

namespace Shipmanagement.Models
{
    public class Ship : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
