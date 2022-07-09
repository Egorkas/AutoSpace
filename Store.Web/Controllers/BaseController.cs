using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    [Route("web/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
