using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Instances
    {
        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject] 
        private IInstancesService _instancesService { get; set; }
        [Inject]
        private IInstanceService _instanceService { get; set; }
        
        private bool _serverAvailable = false;
        private bool _loading = true;
        
        public ModalNewInstance ModalNewInstance { get; set; }

        private List<InstanceViewModel> _data = new List<InstanceViewModel>();
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.InstanceServer);
            _data = await _instancesService.GetAllInstances();
            _loading = false;
        }
        
        private void ShowModalNewInstance()
        {
            this.ModalNewInstance.Show();
        }

        private void OpenOrg(Guid id)
        {
            _instanceService.Id = id;
            NavigationManager.NavigateTo("/instance");
        }
        
    }
}