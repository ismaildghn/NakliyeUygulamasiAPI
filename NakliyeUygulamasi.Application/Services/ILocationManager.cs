using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Services
{
    public interface ILocationManager
    {
          Task PopulateDatabaseAsync();
    }
}
