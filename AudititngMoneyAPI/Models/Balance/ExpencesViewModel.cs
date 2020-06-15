using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudititngMoneyAPI.Models.Balance
{
    public class ExpencesViewModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }
        public DateTime Date { get; set; }

        public string Note { get; set; }

    }
}
