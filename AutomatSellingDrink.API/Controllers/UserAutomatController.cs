using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.API.Extensions;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User = AutomatSellingDrink.API.Contracts.User;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAutomatController: ControllerBase
    {
        private readonly IUserAutomatService _userAutomatService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public UserAutomatController(IUserAutomatService userAutomatService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _userAutomatService = userAutomatService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }
        
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("depositcoins")]
        public async Task<IActionResult> DepositCoin(Contracts.Coin coin)
        {
            Core.Models.Coin result = null;
            try
            {
                var user = _httpContextAccessor.HttpContext.Session.Get<Core.Models.User>("user");
                result = new Coin()
                {
                    Cost = coin.Cost,
                    UserId = user.Id
                };
                _userAutomatService.DepositCoin(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getchange")]
        public async Task<IActionResult> GetChange()
        {
            var user = _httpContextAccessor.HttpContext.Session.Get<Core.Models.User>("user");
            Core.Models.Coin[] result = null;
            try
            {
                result = await _userAutomatService.GetChange(user);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
            
            return Ok(result);
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledepositcoins")]
        public async Task<IActionResult> GetAvailableDepositCoins()
        {
            List<Contracts.Coin> result = new List<Contracts.Coin>();
            try
            {
                var coins = await _userAutomatService.GetAvailableDepositCoins();
                foreach (var coin in coins)
                {
                    result.Add(_mapper.Map<Core.Models.Coin,Contracts.Coin>(coin));
                }
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }

            return Ok(result.ToArray());
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("buyDrink")]
        public async Task<IActionResult> BuyDrink(Contracts.Drink drink)
        {
            var user = _httpContextAccessor.HttpContext.Session.Get<Core.Models.User>("user");
            await _userAutomatService.BuyDrink(_mapper.Map<Contracts.Drink, Core.Models.Drink>(drink), user);

            return Ok();
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledrinks")]
        public void GetAvailableDrinks()
        {
            
        }
        
    }
}