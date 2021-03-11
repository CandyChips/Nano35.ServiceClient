﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectUnitsType
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Parameter] public EventCallback<Guid> OnSelectedUnitsTypeChanged { get; set; }
        
        private Guid _selectedUnitsTypeId;
        private Guid SelectedUnitsTypeId { get => _selectedUnitsTypeId; set { _selectedUnitsTypeId = value; OnUnitsTypeChanged(); } }

        
        private List<UnitTypeViewModel> Types { get; set; }
        private bool _loading = true;
        
        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllUnitTypesHttpQuery();
            Types = (await new GetAllUnitTypesRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
            _loading = false;
        }

        private void OnUnitsTypeChanged()
        {
            OnSelectedUnitsTypeChanged.InvokeAsync(_selectedUnitsTypeId);
        }
        
    }
    
}