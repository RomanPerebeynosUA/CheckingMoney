using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.TransferEntity
{
    public class TransferFrom
    {
        public int Id { get; set; }

        public int Id_Transfer { get; set; }

        public Transfer Transfer { get; set; }


        public int Id_Account { get; set; }

        public CashAccount CashAccount { get; set; }
    }
}
