using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Logout :
        ComponentBase
    {     
        [Inject] private IAuthService AuthService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await AuthService.LogOut();
            NavigationManager.NavigateTo("/log-in");
        }
        
    }
}