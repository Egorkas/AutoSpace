using Microsoft.AspNetCore.Mvc;
using Store.Application.Shops.Queries;

namespace Store.Web.Controllers
{
    public class ShopController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetShopQuery();
            var shopList = await Mediator.Send(query);
            return View(shopList);
        }
    }
}
