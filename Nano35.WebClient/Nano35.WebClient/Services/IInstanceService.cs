﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Pages;

namespace Nano35.WebClient.Services
{
    public interface IInstanceService
    {
        public IInstanceViewModel Instance { get; set; }
        IInstanceViewModel GetCurrentInstance();
        Task SetInstanceById(Guid id);
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
        public IInstanceViewModel Instance { get; set; }
        
        public IInstanceViewModel GetCurrentInstance()
        {
            return Instance;
        }
        
        public async Task SetInstanceById(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_requestManager.InstanceServer}/Instances/GetInstanceById/Id={id}");
            if (response.IsSuccessStatusCode)
            {
                Instance = (await response.Content.ReadFromJsonAsync<GetInstanceByIdSuccessHttpResponse>())?.Data;
            }
        }

        


    }
}