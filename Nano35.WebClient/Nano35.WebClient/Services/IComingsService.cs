using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nano35.Contracts.Instance.Artifacts;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.HttpContext.storage;

namespace Nano35.WebClient.Services
{
    public interface IComingsService
    {
        Task<GetAllComingsSuccessHttpResponse> GetAllComings(Guid instanceId);
    }
    
    public class ComingsService :
        IComingsService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestManager _requestManager;

        public ComingsService(
            HttpClient httpClient,
            IRequestManager requestManager)
        {
            _httpClient = httpClient;
            _requestManager = requestManager;
        }

        public async Task<GetAllComingsSuccessHttpResponse> GetAllComings(Guid instanceId)
        {
            var response = await _httpClient.GetAsync($"http://192.168.100.210:30003/Warehouse/GetAllComings?InstanceId={instanceId}");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllComingsSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
    }
}