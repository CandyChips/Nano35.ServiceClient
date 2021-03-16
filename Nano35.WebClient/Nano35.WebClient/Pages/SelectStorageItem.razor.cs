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
    public partial class SelectStorageItem : 
        ComponentBase
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public EventCallback<Guid> OnSelectedStorageItemChanged { get; set; }
        
        private List<StorageItemViewModel> StorageItems { get; set; }
        private Guid _selectedStorageItemId;
        private Guid SelectedStorageItemId { get => _selectedStorageItemId; set { _selectedStorageItemId = value; OnSelectedStorageItemChanged.InvokeAsync(_selectedStorageItemId); } }
        private bool _isNewStorageItemDisplay = false;
        private bool _loading = true;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            StorageItems = await GetAllStorageItems();
            _loading = false;
        }

        private async Task<List<StorageItemViewModel>> GetAllStorageItems()
        {
            return (await new GetAllStorageItemsRequest(RequestManager, HttpClient, new GetAllStorageItemsQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId()}).Send()).Data.ToList();
        }

        private void ShowModalNewStorageItem() => _isNewStorageItemDisplay = true;

        private async void HideModalNewStorageItem()
        {
            StorageItems = await GetAllStorageItems();
            _isNewStorageItemDisplay = false;
        }
    }
        
}