using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeShopping.API.Dtos;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Core.Service;
using SafeShopping.Service.Services;

namespace SafeShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccountService _accountService;
        
        private readonly IMapper _mapper;
        public HomeController(IAccountService accountService,IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;

        }
        

        [HttpPost]
        public async Task<IActionResult> SignUp(AccountDto accountDto)
        {
                       
            var addedAccount = await _accountService.AddWithMernisAuth(_mapper.Map<Account>(accountDto));
            return Created(string.Empty, _mapper.Map<AccountDto>(addedAccount));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }




    }
}
