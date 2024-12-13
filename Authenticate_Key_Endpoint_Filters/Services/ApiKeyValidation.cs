using Authenticate_Key_Endpoint_Filters.Config;

namespace Authenticate_Key_Endpoint_Filters.Services
{
    public class ApiKeyValidation(IConfiguration configuration) : IApiKeyValidation
    {
        private readonly IConfiguration _configuration = configuration;

        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey))
                return false;

            var apiKey = _configuration.GetValue<string>(Constant.ApiKeyName);

            if (apiKey == null || apiKey != userApiKey)
                return false;

            return true;
        }
    }
}
