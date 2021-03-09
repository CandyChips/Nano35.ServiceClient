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
    public partial class ModalEditClient : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager RequestManager { get; set; }
        [Inject] 
        private IInstanceService InstanceService { get; set; }
        [Inject] 
        private IClientService Clientservice { get; set; }
        [Inject] 
        private ISessionProvider SessionProvider { get; set; }
        
        private IEnumerable<IClientTypeViewModel> Types { get; set; }
        private IEnumerable<IClientStateViewModel> State { get; set; }

        private ClientViewModel _model = new ClientViewModel();
        private bool _loading = true;
        private string _error;
        private bool _serverAvailable = false;
        
        public bool Display { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            State = (await Clientservice.GetAllClientStates()).Data;
            Types = (await Clientservice.GetAllClientTypes()).Data;
            _loading = false;
        }

        public void Show(Guid id)
        {
            this.Display = true;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Hide()
        {
            this.Display = false;
            this.InvokeAsync(this.StateHasChanged);
        }
    }
}