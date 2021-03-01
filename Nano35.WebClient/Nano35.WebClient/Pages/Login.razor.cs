using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.identity;
using Nano35.WebClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Nano35.WebClient.Pages
{
    public partial class Login
    {
        // ToDo add healthcheck to identity server and add firewall on server not found
        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        private ITokenService _tokenService { get; set; }

        // ToDo add [Required] attribute to model on httpcontext project
        private GenerateUserTokenHttpContext.GenerateUserTokenBody model = new GenerateUserTokenHttpContext.GenerateUserTokenBody();
        private bool loading;
        private string error;

        protected override void OnInitialized()
        {
            // ToDo implement healthcheck here!!!
            //if (_requestManager.HealthCheck(_requestManager.IdentityServer))
            //{
            //}
            //else
            //{
            //    NavigationManager.NavigateTo("/service-unavailable");
            //}
            if (_tokenService.IsTokenExist())
            {
                NavigationManager.NavigateTo("/");
            }       
        }

        // ToDo responce of request shown on second click to button
        // message require any action to appear after button click
        private async void HandleValidSubmit()
        
        {
            try
            {
                await _authService.Login(model);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

    }
}
