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
    public partial class ModalNewClient : ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private IClientService ClientService { get; set; }
        [Parameter] public EventCallback OnHideModalNewClient { get; set; }
        
        private IEnumerable<IClientTypeViewModel> Types { get; set; }
        private IEnumerable<IClientStateViewModel> State { get; set; }
        
        private CreateClientHttpBody _model = new CreateClientHttpBody();
        private bool _loading = true;
        private string _error;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            State = (await ClientService.GetAllClientStates()).Data;
            Types = (await ClientService.GetAllClientTypes()).Data;
            _loading = false;
        }

        private async void HideModalNewStorageItem() =>
            await OnHideModalNewClient.InvokeAsync();

        private void Create()
        {
            _model.NewId = Guid.NewGuid();
            _model.InstanceId = InstanceService.GetCurrentInstance().Id;
            ClientService.CreateClient(_model);
        }
    }
}