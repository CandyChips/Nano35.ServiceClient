using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Logout
    {     
        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await _authService.LogOut();
            NavigationManager.NavigateTo("/log-in");
        }
        
    }
}