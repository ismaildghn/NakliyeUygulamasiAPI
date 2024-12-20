﻿using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Domain.Entities;
using NakliyeUygulamasi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(NakliyeUygulamasiAPIDbContext context) : base(context)
        {
        }
    }
}
