using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudititngMoneyAPI.Models.Balance
{
    public class CashAccountViewModel
    {
        public string Name { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }

        public int Balance_Id { get; set; }

    }
}
