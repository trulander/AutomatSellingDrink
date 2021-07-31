using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutomatSellingDrink.API.Contracts;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Balance = AutomatSellingDrink.API.Contracts.Balance;
using Coin = AutomatSellingDrink.Core.Models.Coin;
using Drink = AutomatSellingDrink.API.Contracts.Drink;
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
        //
        // [HttpOptions("depositcoins")]
        // public async Task<IActionResult> DepositCoinCORS()
        // {
        //     return Ok();
        // }
        
        [ProducesResponseType(typeof(Contracts.Balance), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("depositcoins")]
        public async Task<IActionResult> DepositCoin(Contracts.Coin coin)
        {
            Balance result = new Balance();
            try
            {
                var newCoin = new Coin()
                {
                    Cost = coin.Cost
                };
                result = _mapper.Map<Core.Models.Balance, Contracts.Balance>(
                        await _userAutomatService.DepositCoinAsync(newCoin)
                    );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
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
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [ProducesResponseType(typeof(Contracts.Balance), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("buyDrink")]
        public async Task<IActionResult> BuyDrinkAsync([FromForm]string name)
        {
            Contracts.Balance summMoney = new Balance();
            try
            {
                summMoney = _mapper.Map<Core.Models.Balance, Contracts.Balance>(
                        await _userAutomatService.BuyDrinkAsync(name)
                    );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(summMoney);
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledrinks")]
        public async Task<IActionResult> GetAvailableDrinksAsync()
        {
            List<Contracts.Drink> result = new List<Drink>();
            try
            {
                var drinks = await _userAutomatService.GetAvailableDrinks();
                foreach (var drink in drinks)
                {
                    result.Add(_mapper.Map<Core.Models.Drink, Contracts.Drink>(drink));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result.ToArray());
        }
        
    }
}