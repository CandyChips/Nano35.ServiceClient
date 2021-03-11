using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectUnit
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<Guid> OnUnitChanged { get; set; }
        
        private IEnumerable<IUnitViewModel> Units { get; set; }
        private Guid _selectedUnitId;
        private bool _loading = true;
        private bool _isNewUnitDisplay = false;
        private Guid SelectedStorageItemId { get => _selectedUnitId; set { _selectedUnitId = value; OnStorageItemChanged(); } }
        
        protected override async Task OnInitializedAsync()
        {
            var unitsRequest = new GetAllUnitsHttpQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId()};
            Units = (await new GetAllUnitsRequest(RequestManager, HttpClient, unitsRequest).Send()).Data;
            _loading = false;
        }
        
        private async Task OnStorageItemChanged() =>
            await OnUnitChanged.InvokeAsync(SelectedStorageItemId);
        
        private void ShowModalNewUnit() => 
            _isNewUnitDisplay = true;
        
        private void HideModalNewUnit() => 
            _isNewUnitDisplay = false;
    }
}