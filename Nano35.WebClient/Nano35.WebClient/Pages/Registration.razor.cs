using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.identity;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Registration
    {
        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        
        private RegisterHttpBody model = new RegisterHttpBody();
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
                await _authService.Register(model);
                NavigationManager.NavigateTo("/log-in");
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
        }
        
    }
}