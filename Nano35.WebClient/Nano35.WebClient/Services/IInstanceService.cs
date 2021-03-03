using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Nano35.WebClient.Services
{
    public interface IInstanceService
    {
        public Guid Id { get; set; }
        
        Task<List<InstanceViewModel>> GetInstanceById();
    }
    public class InstanceService :
        IInstanceService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestManager _requestManager;

        public InstanceService(HttpClient httpClient, IRequestManager requestManager)
        {
            _httpClient = httpClient;
            _requestManager = requestManager;
        }

        public async Task<List<InstanceViewModel>> GetInstanceById()
        {
            var response = await _httpClient.GetAsync($"{_requestManager.InstanceServer}/Instances/GetInstanceById/Id={Id}");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<List<InstanceViewModel>>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
        
        public Guid Id { get; set; }
    }
}