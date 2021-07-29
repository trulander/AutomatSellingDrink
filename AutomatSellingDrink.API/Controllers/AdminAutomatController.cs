using System;
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
        private readonly IAdminAutomatRepository _adminAutomatRepository;
        private readonly IMapper _mapper;

        public AdminAutomatController(
            IAdminAutomatRepository adminAutomatRepository,
            IMapper mapper)
        {
            _adminAutomatRepository = adminAutomatRepository;
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
                drink = await _adminAutomatRepository.CreateDrinkAsync(_mapper.Map<Drink, Core.Models.Drink>(newDrink));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<Core.Models.Drink, Contracts.Drink>(drink));
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpDelete("deletedrink")]
        public void DeleteDrink()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPut("updatedrink")]
        public void UpdateDrink()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getdrink")]
        public void GetDrink()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getalldrinks")]
        public void GetAllDrinks()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPut("updatequantitycoins")]
        public void UpdateQuantityCoins()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getquantitycouns")]
        public void GetQuantityCoins()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPut("updateavailabledepositcoins")]
        public void UpdateAvailableDepositCoins()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledepositcoins")]
        public void GetAvailableDepositCoins()
        {
            
        }
    }
}