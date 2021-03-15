using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalEditClient : 
        ComponentBase
    {
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private IClientService ClientService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        
        private IEnumerable<IClientTypeViewModel> Types { get; set; }
        private IEnumerable<IClientStateViewModel> State { get; set; }
        private ClientViewModel _model = new ClientViewModel();
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            State = (await ClientService.GetAllClientStates()).Data;
            Types = (await ClientService.GetAllClientTypes()).Data;
        }
    }
}