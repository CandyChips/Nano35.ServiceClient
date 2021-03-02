using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Instance
    {
        [Inject]
        private IAuthService _authService { get; set; }
        
        protected override void OnInitialized()
        {
            var result = _authService.GetCurrentUser();
        }
        
    }
}