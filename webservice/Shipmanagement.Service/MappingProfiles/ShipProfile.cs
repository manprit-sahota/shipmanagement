using Shipmanagement.Models;
using Shipmanagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipmanagement.Service.MappingProfiles
{
    public class ShipProfile : AutoMapper.Profile
    {
        public ShipProfile()
        {
            // INFO: Mapping for listing page
            CreateMap<Ship, ShipViewModel>();

            // INFO: Mappings for Add Edit Page
            CreateMap<Ship, AddEditShipViewModel>();
            CreateMap<AddEditShipViewModel, Ship>();
        }
    }
}
