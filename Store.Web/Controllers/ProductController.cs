using Microsoft.AspNetCore.Mvc;
using Store.Application.Products;

namespace Store.Web.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByShopId(Guid id)
        {
            var query = new GetProductByShopIdQuery
            {
                ShopId = id
            };
            var products = await Mediator.Send(query);
            return View(products);
        }
    }
}
