using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItemCondition :
        ComponentBase
    {
        [Parameter] public EventCallback<Guid> OnSelectedArticleCategoryChanged { get; set; }
        [Inject] private IStorageItemService StorageItemService { get; set; }

        private List<StorageItemConditionViewModel> _conditions = new List<StorageItemConditionViewModel>();
        private Guid _selectedConditionId;
        private Guid SelectedConditionId { get => _selectedConditionId; set { _selectedConditionId = value; OnStorageItemConditionChanged(); } }
        private bool _isLoading = true;
        
        
        protected override async Task OnInitializedAsync()
        {            
            _conditions = (await StorageItemService.GetAllStorageConditions()).Data.ToList();
            _isLoading = false;
            StateHasChanged();
        }

        private void OnStorageItemConditionChanged()
        {
            OnSelectedArticleCategoryChanged.InvokeAsync(_selectedConditionId);
        }
    }
}