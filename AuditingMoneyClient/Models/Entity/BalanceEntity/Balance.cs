﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.BalanceEntity
{
    public class Balance
    {
        public int Id { get; set; }
        public double Amount { get; set; }


        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<KindOfCurrency> KindOfCurrencies { get; set; }


        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<CashAccount> CashAccounts { get; set; }


    }
}