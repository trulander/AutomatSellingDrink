using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutomatSellingDrink.API.Contracts;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Coin = AutomatSellingDrink.Core.Models.Coin;
using IMapper = AutoMapper.IMapper;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAutomatController: ControllerBase
    {
        private readonly IUserAutomatService _userAutomatService;
        private readonly IMapper _mapper;

        public UserAutomatController(IUserAutomatService userAutomatService, IMapper mapper)
        {
            _userAutomatService = userAutomatService;
            _mapper = mapper;
        }
        
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("depositcoins")]
        public async Task<IActionResult> DepositCoin(Contracts.Coin coin)
        {
            Core.Models.Coin result = null;
            try
            {
                result = new Coin()
                {
                    Cost = coin.Cost,
                    IsUserOwner = true
                    
                };
                await _userAutomatService.DepositCoinAsync(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [ProducesResponseType(typeof(Contracts.Coin[]), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getchange")]
        public async Task<IActionResult> GetChangeAsync()
        {
            List<Contracts.Coin> result = new List<Contracts.Coin>();
            try
            {
                var coins = await _userAutomatService.GetChangeAsync();
                foreach (var coin in coins) 
                {
                    result.Add(_mapper.Map<Core.Models.Coin,Contracts.Coin>(coin));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result.ToArray());
        }

        [ProducesResponseType(typeof(Contracts.Settings), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledepositcoins")]
        public async Task<IActionResult> GetAvailableDepositCoins()
        {
            Contracts.Settings result = null;
            try
            {
                result = _mapper.Map<Core.Models.Settings, Contracts.Settings>(
                    await _userAutomatService.GetAvailableDepositCoins());
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
            return Ok(result);
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("buyDrink")]
        public void BuyDrink()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledrinks")]
        public void GetAvailableDrinks()
        {
            
        }
        
    }
}