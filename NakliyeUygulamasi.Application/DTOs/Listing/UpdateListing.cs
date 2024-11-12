using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs.Listing
{
    public class UpdateListing
    {
        public string ListingId { get; set; }
        public string DeliveryAddresId { get; set; }
        public string PickupAddressId { get; set; }
        public string Description { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
