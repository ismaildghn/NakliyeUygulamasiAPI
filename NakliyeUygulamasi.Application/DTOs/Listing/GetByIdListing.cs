using NakliyeUygulamasi.Application.DTOs.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs.Listing
{
    public class GetByIdListing
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public AddressDto DeliveryAddress { get; set; }
        public AddressDto PickUpAddress { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime ListingCreatedDate { get; set; }
    }
}
