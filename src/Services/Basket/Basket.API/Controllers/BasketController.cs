using Basket.API.Entites;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController: ControllerBase
    {
        private readonly IBasketRepository _basket;

        public BasketController(IBasketRepository basket)
        {
            _basket = basket;
        }
        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var baseket = await _basket.GetBasket(userName);
            return Ok(baseket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart shoppingCart)
        {
           
                var basket = await _basket.UpdateBasket(shoppingCart);
                return Ok(basket);
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await _basket.DeleteBasket(userName);
            return Ok();
        }

    }
}
