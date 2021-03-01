using Nano35.Contracts.Identity.Artifacts;
using Nano35.HttpContext.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Nano35.WebClient.Services
{
    public interface IAuthService
    {
        Task Login(GenerateUserTokenBody loginRequest); 
        Task Logout();
    }

    public class AuthService : IAuthService
    {
        private readonly IRequestManager _requestManager;
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public AuthService(
            IRequestManager requestManager,
            ITokenService tokenService,
            HttpClient httpClient)
        {
            _requestManager = requestManager;
            _tokenService = tokenService;
            _httpClient = httpClient;
        }

        public async Task Login(GenerateUserTokenBody loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_requestManager.IdentityServer}/Identity/Authenticate", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(
                    result.Content.ReadFromJsonAsync<GenerateTokenErrorResultContract>().Result.Message);
            else
                _tokenService.SaveToken(
                    result.Content.ReadFromJsonAsync<GenerateTokenSuccessResultContract>().Result.Token);
        }

        public async Task Logout()
        {
            _tokenService.RemoveToken();
        }

        // ToDo move to httpcontext
        class GenerateTokenErrorResultContract :
            IGenerateTokenErrorResultContract
        {
            public string Message { get; set; }
        }

        // ToDo move to httpcontext
        class GenerateTokenSuccessResultContract :
            IGenerateTokenSuccessResultContract
        {
            public string Token { get; set; }
        }
    }
}
