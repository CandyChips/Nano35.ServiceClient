using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nano35.Contracts.Instance.Artifacts;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;

namespace Nano35.WebClient.Services
{
    public interface IInstancesService
    {
        Task<GetAllInstancesSuccessHttpResponse> GetAllInstances();
    }
    
    public class InstancesService :
        IInstancesService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestManager _requestManager;

        public InstancesService(HttpClient httpClient, IRequestManager requestManager)
        {
            _httpClient = httpClient;
            _requestManager = requestManager;
        }

        public async Task<GetAllInstancesSuccessHttpResponse> GetAllInstances()
        {
            var response = await _httpClient.GetAsync($"{_requestManager.InstanceServer}/Instances/GetAllCurrentInstances");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllInstancesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
    }
    
    public class InstanceViewModel
    {
        public Guid Id { get; set; }
        public string OrgName { get; set; }
        public string OrgRealName { get; set; }
        public string OrgEmail { get; set; }
        public string CompanyInfo { get; set; }
        public Guid RegionId { get; set; }
    }
}