using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using StoreService.Services.CashService;
using System.Text;

namespace StoreWeb.Helper
{
    public class CashAttribute : Attribute,IAsyncActionFilter
    {
        private readonly int _timeToLiveInSeconds;

        public CashAttribute(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();
            var cashKey = GenerateCashKeyFromRequest(context.HttpContext.Request);
            var cashedResponse = await _cashService.GetCashResponseAsync(cashKey);
            if (!string.IsNullOrEmpty(cashedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cashedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };

                context.Result = contentResult;
                return;
            }

            var executedContext = await next();
            if (executedContext.Result is OkObjectResult response)
            {
                await _cashService.SetCashResponseAsync(cashKey, response.Value, TimeSpan.FromSeconds(_timeToLiveInSeconds));
            }
        }

        private string GenerateCashKeyFromRequest(HttpRequest request)
        {
            StringBuilder cashKey = new StringBuilder();
            cashKey.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                cashKey.Append($"|{key}-{value}");
            }
            return cashKey.ToString();
        }
    }
}
