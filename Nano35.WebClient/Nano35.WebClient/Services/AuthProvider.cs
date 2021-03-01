using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;


namespace Nano35.WebClient.Services
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        private readonly HttpClient _httpClient;

        public AuthProvider(
            ITokenService tokenService,
            HttpClient httpClient,
            IAuthService authService)
        {
             _tokenService = tokenService;
             _httpClient = httpClient;
             _authService = authService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_tokenService.IsTokenExist())
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = _tokenService.GetIdentityHeader();
            var responce = _authService.GetUserFromToken();

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, responce.Result.Name),
                new Claim(ClaimTypes.MobilePhone, responce.Result.Phone),
                new Claim(ClaimTypes.NameIdentifier, responce.Result.Id.ToString())
            };
            
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "user")));
        }
    }
}