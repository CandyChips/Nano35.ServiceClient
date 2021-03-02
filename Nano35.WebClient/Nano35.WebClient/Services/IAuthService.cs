﻿using Nano35.Contracts.Identity.Artifacts;
using Nano35.HttpContext.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Nano35.Contracts.Identity.Models;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Services
{
    public interface IAuthService
    {
        Task<IGenerateTokenResultContract> Login(GenerateUserTokenHttpContext.GenerateUserTokenBody loginRequest);
        Task<IGetUserByIdResultContract> GetCurrentUser();
    }

    public class AuthService : IAuthService
    {
        private readonly IRequestManager _requestManager;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider  _customAuthenticationStateProvider;

        public AuthService(
            IRequestManager requestManager,
            ILocalStorageService localStorage,
            HttpClient httpClient,
            AuthenticationStateProvider  customAuthenticationStateProvider)
        {
            _requestManager = requestManager;
            _httpClient = httpClient;
            _customAuthenticationStateProvider = customAuthenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<IGenerateTokenResultContract> Login(
            GenerateUserTokenHttpContext.GenerateUserTokenBody loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_requestManager.IdentityServer}/Identity/Authenticate", loginRequest);
            if (result.IsSuccessStatusCode)
            {
                var success = await result.Content.ReadFromJsonAsync<impl1>();
                await _localStorage.SetItemAsync("authToken", success?.Token);
                ((CustomAuthenticationStateProvider) _customAuthenticationStateProvider).NotifyAsAuthenticated(
                    success?.Token);
                return success;
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<impl2>();
            }
        }

        public async Task<IGetUserByIdResultContract> GetCurrentUser()
        {
            var result = await _httpClient.GetAsync($"{_requestManager.IdentityServer}/Identity/GetUserFromToken");
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<impl3>();
            }

            throw new NotImplementedException();
        }
    }

    public class impl1 : IGenerateTokenSuccessResultContract
    {
        public string Token { get; set; }
    }

    public class impl2 : IGenerateTokenErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class impl3 : IGetUserByIdSuccessResultContract
    {
        public IUserViewModel Data { get; set; }
    }
}