﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.WebClient.Services;
using InstanceViewModel = Nano35.HttpContext.instance.InstanceViewModel;

namespace Nano35.WebClient.Pages
{
    public partial class Instances :
        ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstancesService InstancesService { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback OnHideModalNewInstance { get; set; }

        private bool _serverAvailable = false;
        private bool _loading = true;
        private bool _isNewInstanceDisplay = false;

        private IEnumerable<InstanceViewModel> _data;
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.InstanceServer);
            _data = (await InstancesService.GetAllInstances()).Data;
            _loading = false;
        }

        private async Task OpenOrg(Guid id)
        {
            await InstanceService.SetInstanceById(id);         //get session
            await SessionProvider.SetCurrentInstanceId(id);    //set instance id
            NavigationManager.NavigateTo("/instance-view");
        }
        
        private void HideModalNewInstance() => 
            _isNewInstanceDisplay = false;
        
        private void ShowModalNewInstance() => 
            _isNewInstanceDisplay = true;
        
    }
}