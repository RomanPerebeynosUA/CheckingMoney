using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.TransferEntity
{
    public class TransferFrom
    {
        public int Id { get; set; }

        public Transfer Transfer { get; set; }

        public CashAccount CashAccount { get; set; }
    }
}
