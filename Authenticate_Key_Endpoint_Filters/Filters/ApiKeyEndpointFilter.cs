using Authenticate_Key_Endpoint_Filters.Config;
using Authenticate_Key_Endpoint_Filters.Services;

namespace Authenticate_Key_Endpoint_Filters.Filters
{
    public class ApiKeyEndpointFilter(IApiKeyValidation apiKeyValidation) : IEndpointFilter
    {
        private readonly IApiKeyValidation _apiKeyValidation = apiKeyValidation;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            if (string.IsNullOrWhiteSpace(context.HttpContext.Request.Headers[Constant.ApiKeyHeaderName].ToString()))
                return Results.BadRequest();

            string? apiKey = context.HttpContext.Request.Headers[Constant.ApiKeyHeaderName];
            if (!_apiKeyValidation.IsValidApiKey(apiKey!))
            {
                return Results.Unauthorized();
            }
            return await next(context);
        }
    }
}
