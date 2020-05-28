using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.TransferEntity
{
    public class Transfer
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public List<TransferFrom> TransfersFrom { get; set; }
        public List<TransferTo> TransfersTo { get; set; }


    }
}
