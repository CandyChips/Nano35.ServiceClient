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
        [Inject]
        private IAuthService _authService { get; set; }

        private GenerateUserTokenHttpContext.GenerateUserTokenBody model = new GenerateUserTokenHttpContext.GenerateUserTokenBody();
        private bool loading;
        private string error;
        private bool serverAvailible = true;

        protected override void OnInitialized()
        {
            
        }

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
