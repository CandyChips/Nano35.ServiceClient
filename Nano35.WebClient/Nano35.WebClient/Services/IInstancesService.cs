﻿using System;
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
        Task<GetAllRegionsSuccessHttpResponse> GetAllRegions();
        Task<GetAllInstanceTypesSuccessHttpResponse> GetAllTypes();
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
            var response = await _httpClient.GetAsync($"http://192.168.100.210:30002/Instances/GetAllCurrentInstances");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllInstancesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }

        public async Task<GetAllRegionsSuccessHttpResponse> GetAllRegions()
        {
            var response = await _httpClient.GetAsync($"http://192.168.100.210:30002/Instances/GetAllRegions");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllRegionsSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }

        public async Task<GetAllInstanceTypesSuccessHttpResponse> GetAllTypes()
        {
            var response = await _httpClient.GetAsync($"http://192.168.100.210:30002/Instances/GetAllInstanceTypes");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllInstanceTypesSuccessHttpResponse>());
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