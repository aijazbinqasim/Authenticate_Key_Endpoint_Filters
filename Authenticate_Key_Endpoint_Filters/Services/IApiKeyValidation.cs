namespace Authenticate_Key_Endpoint_Filters.Services
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}
