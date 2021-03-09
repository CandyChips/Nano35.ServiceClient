using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItem : ComponentBase
    {
        [Parameter] public EventCallback<Guid> OnSelectedStorageItemChanged { get; set; }
        [Inject] private IStorageItemService StorageItemService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        
        private List<StorageItemViewModel> Articles { get; set; }
        private Guid _selectedStorageItemId;
        private Guid SelectedStorageItemId { get => _selectedStorageItemId; set { _selectedStorageItemId = value; OnStorageItemChanged(); } }

        private string StorageItem { get; set; }
        private bool _isNewStorageItemDisplay = false;

        private async Task OnStorageItemChanged() =>
            await OnSelectedStorageItemChanged.InvokeAsync(_selectedStorageItemId);
        
        private void ShowModalNewStorageItem() => 
            _isNewStorageItemDisplay = true;
        
        private void HideModalNewStorageItem() => 
            _isNewStorageItemDisplay = false;
    }
        
}