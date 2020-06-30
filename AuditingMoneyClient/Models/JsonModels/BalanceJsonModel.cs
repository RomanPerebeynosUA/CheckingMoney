using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.JsonModels
{
    public class BalanceJsonModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public string UserId { get; set; }
    }
}
