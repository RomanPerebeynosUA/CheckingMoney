using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces.Transfers
{
   public interface ITransferRepository
    {
        Task<string> GetTransfer(string url, string accessToken);
        Task<List<TransferViewModel>> Get(string url, string accessToken);
        Task<HttpResponseMessage> CreateTransfer(string url, string accessToken, TransferJsonModel content);
        List<TransferJsonModel> DeseralizeTransfers(string json);
        TransferJsonModel DeseralizeTransfer(string json);
    }
}
