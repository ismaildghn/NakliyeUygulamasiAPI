using NakliyeUygulamasi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Province : BaseEntity
    {
        public string ProvinceName { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
