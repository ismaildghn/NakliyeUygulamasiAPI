using NakliyeUygulamasi.Domain.Entities.Common;
using NakliyeUygulamasi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
        public Guid TransporterId { get; set; }
        public Transporter Transporter { get; set; }
        public decimal Price { get; set; }
        public OfferStatus Status { get; set; }
    }
}
