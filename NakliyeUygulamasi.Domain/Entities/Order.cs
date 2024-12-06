﻿using NakliyeUygulamasi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string DeliveryAddressId { get; set; }
        public Address DeliveryAddress{ get; set; }
        public string PickupAddressId { get; set; }
        public Address PickupAddress{ get; set; }
        public string Description { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
