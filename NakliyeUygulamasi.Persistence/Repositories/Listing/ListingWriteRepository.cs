using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Domain.Entities;
using NakliyeUygulamasi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Repositories
{
    public class ListingWriteRepository : WriteRepository<Listing>, IListingWriteRepository
    {
        public ListingWriteRepository(NakliyeUygulamasiAPIDbContext context) : base(context)
        {
        }
    }
}
