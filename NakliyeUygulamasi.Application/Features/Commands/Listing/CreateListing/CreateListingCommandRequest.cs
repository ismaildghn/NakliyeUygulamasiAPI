using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.Listing.CreateListing
{
    public class CreateListingCommandRequest : IRequest<CreateListingCommandResponse>
    {
        public Guid DeliveryAddresId { get; set; }
        public Guid PickupAddressId { get; set; }
        public string Description { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
