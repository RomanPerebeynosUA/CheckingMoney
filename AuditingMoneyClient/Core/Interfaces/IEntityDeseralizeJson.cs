using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
   public  interface IEntityDeseralizeJson<T>
    {
        List<T> DeseralizeList(string json);
        T DeseralizeObject(string json);
       
    }
}
