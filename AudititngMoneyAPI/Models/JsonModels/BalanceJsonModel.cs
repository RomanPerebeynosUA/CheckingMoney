using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyAPI.Models.JsonModels
{
    public class BalanceJsonModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}
