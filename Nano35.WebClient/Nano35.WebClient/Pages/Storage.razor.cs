using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Storage
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        
        private bool _serverAvailable;
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.InstanceServer);
            if(!_serverAvailable) NavigationManager.NavigateTo("/instances");
        }   
    }
    
    
}