﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs.Order
{
    public class CreateOrder
    {
        public Guid DeliveryAddresId { get; set; }
        public Guid PickupAddressId { get; set; }
        public string Description { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}