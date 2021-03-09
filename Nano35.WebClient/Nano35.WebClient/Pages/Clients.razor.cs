using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Clients
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager RequestManager { get; set; }
        [Inject]
        private IClientService ClientService { get; set; }
        [Inject]
        private ISessionProvider SessionProvider { get; set; }
        
        private bool _isNewClientDisplay = false;
        private bool _isEditClientDisplay = false;
        
        private bool _serverAvailable = false;
        private bool _loading = true;
        private IEnumerable<ClientViewModel> _data;
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.InstanceServer);
            if(!_serverAvailable)
                NavigationManager.NavigateTo("/instances");
            if (!await SessionProvider.IsCurrentSessionIdExist())
                NavigationManager.NavigateTo("/instances");
            _data = (await ClientService.GetAllClients(await SessionProvider.GetCurrentInstanceId())).Data;
            _loading = false;
        }
        
        private void ShowModalNewClient() => 
            _isNewClientDisplay = true;
        
        private void HideModalNewClient() => 
            _isNewClientDisplay = false;
        
        private void ShowModalEditClient() => 
            _isEditClientDisplay = true;
        
        private void HideModalEditClient() => 
            _isEditClientDisplay = false;
    }
}