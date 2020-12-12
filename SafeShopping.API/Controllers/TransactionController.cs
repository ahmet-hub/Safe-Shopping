using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeShopping.API.Resource;
using SafeShopping.Core.Service;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SafeShopping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        IUserService _userService;
        ITransactionService _transactionService;
        ILoadMoneyService _loadMoneyService;
        public TransactionController(IUserService userService, ITransactionService transactionService, ILoadMoneyService loadMoneyService)
        {
            _userService = userService;
            _transactionService = transactionService;
            _loadMoneyService = loadMoneyService;

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LoadMoney(LoadMoneyResource loadMoneyResource)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Claim> claims = User.Claims;

                string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
                User senderUser = (User)_userService.GetByIdAsync(int.Parse(userId)).Result;
                LoadMoney loadMoney = new LoadMoney
                {
                    Balance = loadMoneyResource.Balance,
                    UserGuid = senderUser.Guid

                };
                _userService.AddMoney(senderUser.Id, loadMoney.Balance);
                await _loadMoneyService.Add(loadMoney);
                return Ok();
            }
            return BadRequest();
            
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Remittance(RemittanceResource remittanceResource)
        {

            if (ModelState.IsValid)
            {
                IEnumerable<Claim> claims = User.Claims;

                string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

                //var data = _userService.GetByIdAsync(int.Parse(userId)).Result;
                User receiverUser = _userService.GetUserWithGuidId(remittanceResource.ReceiverGuid).Result;

                User senderUser = (User)_userService.GetByIdAsync(int.Parse(userId)).Result;

                Transaction transaction = new Transaction()
                {
                    SenderGuid = senderUser.Guid,
                    SenderName = senderUser.Name,
                    SenderLastName = senderUser.SurName,
                    ReceiverGuid = receiverUser.Guid,
                    ReceiverName = receiverUser.Name,
                    ReceiverLastName = receiverUser.SurName,
                    Balance = remittanceResource.Balance,
                    IsSuccessful = false,
                    DateOfOperation = DateTime.Now
                };

                if (senderUser.Balance < remittanceResource.Balance)
                {
                    return BadRequest();
                }

                await _transactionService.Add(transaction);
                _userService.RemoveMoney(senderUser.Id, remittanceResource.Balance);

                return Ok();

            }
            return BadRequest();
        }
        public async Task<IActionResult> Success(bool isSuccess, string Guid)
        {
            //IEnumerable<Claim> claims = User.Claims;

            //string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            //var data = _userService.GetByIdAsync(int.Parse(userId)).Result;
            //User receiverUser = _userService.GetUserWithGuidId(remittanceResource.ReceiverGuid).Result;

            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            User user = (User)_userService.GetByIdAsync(int.Parse(userId)).Result;
            var data = _transactionService.GetTransactionWithUserId(user.Guid);
            return Ok(data);
        }

    }
}
