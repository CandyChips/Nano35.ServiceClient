using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nano35.HttpContext.instance;

namespace Nano35.WebClient.Services
{
    public interface IClientService
    {
        Task<GetAllClientTypesSuccessHttpResponse> GetAllClientTypes();
        Task<GetAllClientStatesSuccessHttpResponse> GetAllClientStates();
        Task CreateClient(CreateClientHttpBody model);
    }


    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestManager _requestManager;

        public ClientService(HttpClient httpClient, IRequestManager requestManager)
        {
            _httpClient = httpClient;
            _requestManager = requestManager;
        }
        
        public async Task<GetAllClientTypesSuccessHttpResponse> GetAllClientTypes()
        {
            var response = await _httpClient.GetAsync($"{_requestManager.InstanceServer}/Clients/GetAllClientTypes");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllClientTypesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
        
        public async Task<GetAllClientStatesSuccessHttpResponse> GetAllClientStates()
        {
            var response = await _httpClient.GetAsync($"{_requestManager.InstanceServer}/Clients/GetAllClientStates");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllClientStatesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }

        public async Task CreateClient(CreateClientHttpBody model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_requestManager.InstanceServer}/Clients/CreateClient", model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
            }
            
        }
    }
    public class GetAllClientStatesRequest : 
        RequestProvider<GetAllClientStatesHttpQuery, GetAllClientStatesSuccessHttpResponse>
    {
        public GetAllClientStatesRequest(IRequestManager requestManager, HttpClient httpClient, GetAllClientStatesHttpQuery request) : 
            base(requestManager, httpClient, request)
        {
            
        }

        public override async Task<GetAllClientStatesSuccessHttpResponse> Send()
        {
            var response = await HttpClient.GetAsync($"{RequestManager.StorageServer}/Clients/GetAllClientStates");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllClientStatesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
    }
    public class GetAllClientTypesRequest : 
        RequestProvider<GetAllClientTypesHttpQuery, GetAllClientTypesSuccessHttpResponse>
    {
        public GetAllClientTypesRequest(IRequestManager requestManager, HttpClient httpClient, GetAllClientTypesHttpQuery request) : 
            base(requestManager, httpClient, request)
        {
            
        }

        public override async Task<GetAllClientTypesSuccessHttpResponse> Send()
        {
            var response = await HttpClient.GetAsync($"{RequestManager.StorageServer}/Clients/GetAllClientTypes");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllClientTypesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<string>()));
        }
    }
}