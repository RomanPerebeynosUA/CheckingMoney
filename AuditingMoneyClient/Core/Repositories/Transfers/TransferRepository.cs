using AuditingMoneyClient.Core.Interfaces.Common;
using AuditingMoneyClient.Core.Interfaces.Transfers;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories.Transfers
{
    public class TransferRepository : ITransferRepository
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactoryRepository _clientFactory;
        public TransferRepository(IMapper mapper,
            IHttpClientFactoryRepository clientFactory)
        {
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateTransfer(string url, string accessToken,
            TransferViewModel content)
        {
            TransferJsonModel transfer = _mapper.Map<TransferViewModel,
               TransferJsonModel>(content);

            var response = await _clientFactory.CreateClient(accessToken)
            .PostAsJsonAsync(url, transfer);

            return response.EnsureSuccessStatusCode();
        }

        public TransferJsonModel DeseralizeTransfer(string json)
        {
            var transfer = JsonConvert.DeserializeObject<TransferJsonModel>(json);
            return transfer;
        }

        public List<TransferJsonModel> DeseralizeTransfers(string json)
        {
            var transfers = JsonConvert.DeserializeObject<List<TransferJsonModel>>(json);
            return transfers;
        }

        public async  Task<string> GetTransfer(string url, string accessToken)
        {
            var response = await _clientFactory.CreateClient(accessToken).GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
        public async Task<List<TransferViewModel>> Get(string url, string accessToken)
        {
            var transfersViewModel = new List<TransferViewModel>();
            var response = await _clientFactory.CreateClient(accessToken).GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadAsStringAsync();

            if (result == null)
            {
                return transfersViewModel;
            }
            var transfers = DeseralizeTransfers(result);

            transfersViewModel = _mapper.Map<List<TransferJsonModel>,
                List<TransferViewModel>>(transfers);

            return transfersViewModel;
        }
    }
}
