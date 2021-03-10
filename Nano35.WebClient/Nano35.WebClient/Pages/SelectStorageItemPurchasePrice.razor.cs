using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItemPurchasePrice
    {
        [Parameter] public EventCallback<decimal> OnStorageItemPurchasePriceChanged { get; set; }
        
        private decimal _storageItemPurchasePrice = 0;

        private decimal StorageItemPurchasePrice
        {
            get => _storageItemPurchasePrice;
            set { 
                OnStorageItemPurchasePriceChanged.InvokeAsync(value);
                _storageItemPurchasePrice = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}