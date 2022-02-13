using System;

namespace Shipmanagement.ViewModels
{
    public class ShipViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}
