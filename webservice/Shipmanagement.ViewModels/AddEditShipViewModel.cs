using System;
using System.Collections.Generic;
using System.Text;

namespace Shipmanagement.ViewModels
{
    public class AddEditShipViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
