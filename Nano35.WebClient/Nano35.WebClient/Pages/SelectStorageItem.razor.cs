using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Storage.Models;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItem : ComponentBase
    {
        [Parameter] public EventCallback<Guid> OnSelectedStorageItemChanged { get; set; }
        [Inject] private IStorageItemService StorageItemService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        
        private List<StorageItemViewModel> StorageItems { get; set; }
        private Guid _selectedStorageItemId;
        private Guid SelectedStorageItemId { get => _selectedStorageItemId; set { _selectedStorageItemId = value; OnStorageItemChanged(); } }
        private bool _isNewStorageItemDisplay = false;
        private bool _loading = true;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            var storageItemsRequest = new GetAllStorageItemsQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId()};
            StorageItems = (await new GetAllStorageItemsRequest(RequestManager, HttpClient, storageItemsRequest).Send()).Data.ToList();
            _loading = false;
        }

        private async Task OnStorageItemChanged() =>
            await OnSelectedStorageItemChanged.InvokeAsync(_selectedStorageItemId);
        
        private void ShowModalNewStorageItem() => 
            _isNewStorageItemDisplay = true;
        
        private void HideModalNewStorageItem() => 
            _isNewStorageItemDisplay = false;
    }
        
}