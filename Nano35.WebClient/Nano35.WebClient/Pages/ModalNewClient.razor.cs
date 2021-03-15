using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewClient : 
        ComponentBase
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Parameter] public EventCallback OnHideModalNewClient { get; set; }
        
        private CreateClientHttpBody _model = new CreateClientHttpBody();
        private List<ClientTypeViewModel> Types { get; set; }
        private List<ClientStateViewModel> State { get; set; }
        private bool _loading = true;
        private string _error = string.Empty;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            State = (await (new GetAllClientStatesRequest(RequestManager, HttpClient, new GetAllClientStatesHttpQuery())).Send()).Data.ToList();
            Types = (await (new GetAllClientTypesRequest(RequestManager, HttpClient, new GetAllClientTypesHttpQuery()).Send())).Data.ToList();
            _loading = false;
        }

        private async void HideModalNewStorageItem() =>
            await OnHideModalNewClient.InvokeAsync();

        private async void Create()
        {
            _model.NewId = Guid.NewGuid();
            _model.InstanceId = InstanceService.GetCurrentInstance().Id;
            await (new CreateClientRequest(RequestManager, HttpClient, _model)).Send();
        }
    }
}