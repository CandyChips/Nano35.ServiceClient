using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nano35.HttpContext.storage;

namespace Nano35.WebClient.Services
{
    public interface IStorageItemService
    {
        Task<GetAllStorageItemConditionsSuccessHttpResponse> GetAllStorageConditions();
    }
    
    public class StorageItemService :
        IStorageItemService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestManager _requestManager;

        public StorageItemService(
            HttpClient httpClient,
            IRequestManager requestManager)
        {
            _httpClient = httpClient;
            _requestManager = requestManager;
        }
        
        public async Task<GetAllStorageItemConditionsSuccessHttpResponse> GetAllStorageConditions()
        {
            var response = await _httpClient.GetAsync($"http://localhost:5003/StorageItems/GetAllStorageItemConditions");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllStorageItemConditionsSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<GetAllStorageItemConditionsErrorHttpResponse>())?.Message);
        }
    }
}