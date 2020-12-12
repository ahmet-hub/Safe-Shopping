using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeShopping.API.Resource;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService _userService;
        IMapper _mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterResource registerResource)
        {
            var data = _mapper.Map<User>(registerResource);

            return Ok(await _userService.Add(data));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }


    }
}
