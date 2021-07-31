using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.API.Contracts;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminAutomatController: ControllerBase
    {
        private readonly IAdminAutomatService _adminAutomatService;
        private readonly IMapper _mapper;

        public AdminAutomatController(
            IAdminAutomatService adminAutomatService,
            IMapper mapper)
        {
            _adminAutomatService = adminAutomatService;
            _mapper = mapper;
        }
        [ProducesResponseType(typeof(Contracts.Drink), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("createdrink")]
        public async Task<IActionResult> CreateDrinkAsync(Contracts.Drink newDrink)
        {
            Core.Models.Drink drink = null;
            try
            {
                drink = await _adminAutomatService.CreateDrinkAsync(_mapper.Map<Drink, Core.Models.Drink>(newDrink));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<Core.Models.Drink, Contracts.Drink>(drink));
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpDelete("deletealldrinksbyname")]
        public async Task<IActionResult> DeleteDrinkByNameAsync(string nameDrink)
        {
            await _adminAutomatService.DeleteDrinkByNameAsync(nameDrink);
            return Ok();
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPut("updatedrink")]
        public async Task<IActionResult> UpdateDrinkAsync(Contracts.Drink drink)
        {
            Core.Models.Drink result = null;
            result = await _adminAutomatService.UpdateDrinkAsync(_mapper.Map<Contracts.Drink,Core.Models.Drink>(drink));
            
            return Ok(_mapper.Map<Core.Models.Drink, Contracts.Drink>(result));
        }


        [ProducesResponseType(typeof(Contracts.CoinAdmin), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getalldrinks")]
        public async Task<IActionResult> GetAllDrinksAsync()
        {
            List<Contracts.CoinAdmin> result = new List<Contracts.CoinAdmin>();
            var coreCoins = await _adminAutomatService.GetAllDrinksAsync();
            foreach (var coin in coreCoins)
            {
                result.Add(new Contracts.CoinAdmin()
                {
                    Cost = coin.Cost,
                    Count = coin.Count
                });
            }

            return Ok(result.ToArray());
        }

        [ProducesResponseType(typeof(Contracts.CoinAdmin), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("createcoin")]
        public async Task<IActionResult> CreateCoinAsync(Contracts.CoinAdmin coin)
        {
            Core.Models.Coin result = null;
            try
            {
                result = await _adminAutomatService.CreateCoinAsync(_mapper.Map<Contracts.CoinAdmin, Core.Models.Coin>(coin));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<Core.Models.Coin, Contracts.CoinAdmin>(result));
        }

        [ProducesResponseType(typeof(Contracts.CoinAdmin), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getcoins")]
        public async Task<IActionResult> GetAllCoinsAsync()
        {
            List<Contracts.CoinAdmin> result = new List<Contracts.CoinAdmin>();
            try
            {
                foreach (var coin in await _adminAutomatService.GetAllCoinsAsync())
                {
                    result.Add(_mapper.Map<Core.Models.Coin, Contracts.CoinAdmin>(coin));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok(result);
        }

        [ProducesResponseType(typeof(Contracts.CoinAdmin), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPut("updatecoin")]
        public async Task<IActionResult> UpdateCoinAsync(Contracts.CoinAdmin coin)
        {
            Contracts.CoinAdmin result = null;
            try
            {
                var updatedCoin = await _adminAutomatService.UpdateCoinAsync(_mapper.Map<Contracts.CoinAdmin, Core.Models.Coin>(coin));
                result = _mapper.Map<Core.Models.Coin, Contracts.CoinAdmin>(updatedCoin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(result);
        }
    }
}