using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.WebClient.Services;
using InstanceViewModel = Nano35.HttpContext.instance.InstanceViewModel;

namespace Nano35.WebClient.Pages
{
    public partial class Instances
    {
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

        private IEnumerable<InstanceViewModel> _data;
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.InstanceServer);
            _data = (await _instancesService.GetAllInstances()).Data;
            _loading = false;
        }
        
        private void ShowModalNewInstance()
        {
            this.ModalNewInstance.Show();
        }

        private async Task OpenOrg(Guid id)
        {
            await _instanceService.SetInstanceById(id);
            NavigationManager.NavigateTo("/instance-view");
        }
        
    }
}