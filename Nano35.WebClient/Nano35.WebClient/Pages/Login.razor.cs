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
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager _requestManager { get; set; }

        private GenerateUserTokenHttpBody model = new GenerateUserTokenHttpBody();
        private bool _loading = true;
        private string _error;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.IdentityServer);
            _loading = false;
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
                _error = ex.Message;
            }
        }

    }
}
