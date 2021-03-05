﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Storage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject]
        private IInstanceService _instanceService { get; set; }
        [Inject]
        private ISessionProvider _sessionProvider { get; set; }
        
        private bool _serverAvailable = false;
        private bool _loading = true;
        protected override async Task OnInitializedAsync()
            {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.InstanceServer);
                if(!_serverAvailable)
            NavigationManager.NavigateTo("/instances");
            if (!await _sessionProvider.IsCurrentSessionIdExist())
            NavigationManager.NavigateTo("/instances");
            _loading = false;
            }
    }
    
    
}