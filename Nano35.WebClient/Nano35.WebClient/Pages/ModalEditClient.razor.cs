﻿using System;
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
        private IRequestManager _requestManager { get; set; }
        [Inject] 
        private IInstanceService _instanceService { get; set; }
        [Inject] 
        private IClientService _clientservice { get; set; }
        [Inject] 
        private ISessionProvider _sessionProvider { get; set; }
        
        private IEnumerable<IClientTypeViewModel> _types { get; set; }
        private IEnumerable<IClientStateViewModel> _state { get; set; }

        private ClientViewModel model = new ClientViewModel();
        private bool _loading = true;
        private string _error;
        private bool _serverAvailable = false;
        
        public bool Display { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.IdentityServer);
            _state = (await _clientservice.GetAllClientStates()).Data;
            _types = (await _clientservice.GetAllClientTypes()).Data;
            _loading = false;
        }

        private async void HandleValidSubmit()
        {
        }
        
        public void Show(Guid id)
        {
            //model = _clientservice.GetClientById(Id).Result.Data;
            this.Display = true;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Hide()
        {
            this.Display = false;
            this.InvokeAsync(this.StateHasChanged);
        }

        public async void Edit()
        {
            
        }
    }
}