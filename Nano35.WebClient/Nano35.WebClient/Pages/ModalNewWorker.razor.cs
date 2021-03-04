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
    public partial class ModalNewWorker : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject] 
        private IWorkerService _workerService { get; set; }
        [Inject] 
        private IInstanceService _instanceService { get; set; }
        
        private IEnumerable<IWorkersRoleViewModel> _types { get; set; }
        private IEnumerable<IRegionViewModel> _regions { get; set; }
        
        private CreateWorkerHttpBody model = new CreateWorkerHttpBody();
        private bool _loading = true;
        private string _error;
        private bool _serverAvailable = false;
        
        public bool Display { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.IdentityServer);
            _types = (await _workerService.GetAllWorkerRoles()).Data;
            _loading = false;
        }

        private async void HandleValidSubmit()
        {
        }
        
        public void Show()
        {
            this.Display = true;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Hide()
        {
            this.Display = false;
            this.InvokeAsync(this.StateHasChanged);
        }
        
        public void Create()
        {
            model.NewId = Guid.NewGuid();
            model.InstanceId = _instanceService.GetCurrentInstance().Id;
            _workerService.CreateWorker(model);
            Hide();
        }
    }
}