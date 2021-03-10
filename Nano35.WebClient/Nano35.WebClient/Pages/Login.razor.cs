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
    public partial class Login :
        ComponentBase
    {
        [Inject] private IAuthService AuthService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }

        private GenerateUserTokenHttpBody _model = new GenerateUserTokenHttpBody();
        private bool _loading = true;
        private string _error;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _loading = false;
        }

        private async void HandleValidSubmit()
        {
            try
            {
                await AuthService.Login(_model);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
        }

    }
}
