using System.Net;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAutomatController: ControllerBase
    {
        private readonly IUserAutomatService _userAutomatService;

        public UserAutomatController(IUserAutomatService userAutomatService)
        {
            _userAutomatService = userAutomatService;
        }
        
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpPost("depositcoins")]
        public void DepositCoins()
        {
            _userAutomatService.DepositCoins();
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getchange")]
        public void GetChange()
        {
            
        }

        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.BadRequest)]
        [HttpGet("getavailabledepositcoins")]
        public void GetAvailableDepositCoins()
        {
            
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