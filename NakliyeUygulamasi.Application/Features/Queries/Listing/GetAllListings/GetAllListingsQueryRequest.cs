using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetAllListings
{
    public class GetAllListingsQueryRequest : IRequest<GetAllListingsQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
