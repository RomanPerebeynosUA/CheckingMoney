using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using AuditingMoney.Entity.Domain.TransferEntity;
using AuditingMoney.Entity.JsonModels;
using AuditingMoneyCore.Interfaces.Transfers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IMapper _mapper;

        public TransferController(ITransferRepository transferRepository,
            IMapper mapper)
        {
            _transferRepository = transferRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var transfers = await _transferRepository.GetListItems();

            if (transfers == null)
            {
                return null;
            }
            else
            {
                return new JsonResult(transfers);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTransferFrom(int id)
        {
            var transfers = await _transferRepository.GetListItemsRemittanceFrom(id);

            if (transfers == null)
            {
                return null;
            }
            else
            {
                return new JsonResult(transfers);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTransferTo(int id)
        {
            var transfers = await _transferRepository.GetListItemsRemittanceTo(id);

            if (transfers == null)
            {
                return null;
            }
            else
            {
                return new JsonResult(transfers);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransferJsonModel transferJson)
        {
            if (transferJson == null)
            {
                return BadRequest();
            }

            var transfer = _mapper.Map<TransferJsonModel, Transfer>(transferJson);
            transfer.Date = DateTime.Now;
            await _transferRepository.Create(transfer);

            await _transferRepository.CreateComunication(
                await _transferRepository.GetItemByDate(transfer.Date),
                transferJson.CashAccountFrom_Id,
                transferJson.CashAccountTo_Id);
               
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(TransferJsonModel transferJson)
        {
            if (transferJson == null)
            {
                return BadRequest();
            }
            if (!_transferRepository.Exists(transferJson.Id))
            {
                return NotFound();
            }
            var transfer = _mapper.Map<TransferJsonModel, Transfer>(transferJson);
            await _transferRepository.Update(transfer);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Transfer transfer = await _transferRepository.GetItem(id);
            if (transfer == null)
            {
                return NotFound();
            }
            await _transferRepository.Remove(transfer);
            return Ok();
        }
    }
}