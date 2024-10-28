﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.Address.CreateDeliveryAddress
{
    public class CreateDeliveryAddressCommandRequest : IRequest<CreateDeliveryAddressCommandResponse>
    {
            public Guid CustomerId { get; set; }
            public int ProvinceId { get; set; }
            public int DistrictId { get; set; }
            public int NeighbourhoodId { get; set; }
            public string StreetAddress { get; set; }
    }
}