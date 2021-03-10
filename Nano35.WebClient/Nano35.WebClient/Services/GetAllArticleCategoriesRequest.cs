﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nano35.HttpContext.storage;

namespace Nano35.WebClient.Services
{
    public class GetAllArticleCategoriesRequest : 
        RequestProvider<GetAllArticlesCategoriesHttpQuery, GetAllArticleCategoriesSuccessHttpResponse>
    {
        public GetAllArticleCategoriesRequest(IRequestManager requestManager, HttpClient httpClient, GetAllArticlesCategoriesHttpQuery request) : 
            base(requestManager, httpClient, request)
        {
            
        }

        public override async Task<GetAllArticleCategoriesSuccessHttpResponse> Send()
        {
            var response = await HttpClient.GetAsync($"{RequestManager.StorageServer}/Category/GetAllArticleCategories?InstanceId={Request.InstanceId}");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllArticleCategoriesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
    }
}