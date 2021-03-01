using Nano35.Contracts.Identity.Artifacts;
using Nano35.HttpContext.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Identity.Models;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Services
{
    public interface IAuthService
    {
        Task Login(GenerateUserTokenHttpContext.GenerateUserTokenBody loginRequest);
        Task<IUserViewModel> GetUserFromToken();
        Task Logout();
        public IUserViewModel User { get; set; }
        public bool IsLogIn();
    }

    }

    public class AuthService : IAuthService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IRequestManager _requestManager;
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public AuthService(
            NavigationManager navigationManager,
            IRequestManager requestManager,
            ITokenService tokenService,
            HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _requestManager = requestManager;
            _tokenService = tokenService;
            _httpClient = httpClient;
        }

        public async Task Login(GenerateUserTokenHttpContext.GenerateUserTokenBody loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_requestManager.IdentityServer}/Identity/Authenticate", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(
                    result.Content.ReadFromJsonAsync<GenerateUserTokenHttpContext.GenerateUserTokenErrorResponse>().Result.Message);
            else
                _tokenService.SaveToken(
                    result.Content.ReadFromJsonAsync<GenerateUserTokenHttpContext.GenerateUserTokenSuccessResponse>().Result.Token);
                _navigationManager.NavigateTo("/");
        }

        public async Task<IUserViewModel> GetUserFromToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_requestManager.IdentityServer}/Identity/GetUserFromToken");
            if (_tokenService.IsTokenExist())
                request.Headers.Authorization = _tokenService.GetIdentityHeader();
            var result  = await _httpClient.SendAsync(request);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(
                    result.Content.ReadFromJsonAsync<GetUserFromTokenHttpContext.GetUserFromTokenErrorResponse>().Result.Message);
            else
                return result.Content.ReadFromJsonAsync<GetUserFromTokenHttpContext.GetUserFromTokenSuccessResponse>().Result.Data;
        }

        public async Task Logout()
        {
            _tokenService.RemoveToken();
            _navigationManager.NavigateTo("/log-in");
        }

        public bool IsLogIn()
        {
            if (_tokenService.IsTokenExist())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IUserViewModel User { get; set; }
    }
