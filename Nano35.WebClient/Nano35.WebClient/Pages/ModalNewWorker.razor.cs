using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewWorker : ComponentBase
    {
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IWorkerService WorkerService { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Parameter] public EventCallback OnHideModalNewWorker { get; set; }
        
        private List<WorkersRoleViewModel> Types { get; set; }
        private CreateWorkerHttpBody _model;
        private bool _loading = true;
        private string _error = "";
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            Types = (await WorkerService.GetAllWorkerRoles()).Data.ToList();
            _loading = false;
        }

        private async void HandleValidSubmit()
        {
        }
        
        private void HideModalNewWorker()
        {
            OnHideModalNewWorker.InvokeAsync();
        }
        
        public void Create()
        {
            _model.NewId = Guid.NewGuid();
            _model.InstanceId = InstanceService.GetCurrentInstance().Id;
            WorkerService.CreateWorker(_model);
            OnHideModalNewWorker.InvokeAsync();
        }
    }
}