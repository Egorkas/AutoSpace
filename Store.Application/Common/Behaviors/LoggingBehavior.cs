using Serilog;
using MediatR;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Common.Behaviors
{
    public class LoggingBehavior<Trequest, TResponce>
        : IPipelineBehavior<Trequest, TResponce> where Trequest
        : IRequest<TResponce>
    {
        public async Task<TResponce> Handle(Trequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponce> next)
        {
            var requestName = typeof(Trequest).Name;
            Log.Information("Notes Request: {Name}  {@Request}",
                requestName, request);

            var responce = await next();

            return responce;
        }
    }
}
