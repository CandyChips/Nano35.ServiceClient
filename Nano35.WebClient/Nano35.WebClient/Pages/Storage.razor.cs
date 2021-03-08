﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Storage
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        [Inject] private IRequestManager RequestManager { get; set; }
        
        [Inject] private ISessionProvider SessionProvider { get; set; }
        
        private bool _serverAvailable = false;

        private bool _loading = true;
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.InstanceServer);
            if(!_serverAvailable)
                NavigationManager.NavigateTo("/instances");
            _loading = false;
        }   
    }
    
    
}