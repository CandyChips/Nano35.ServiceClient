using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItemRetailPrice
    {
        [Parameter] public EventCallback<decimal> OnStorageItemRetailPriceChanged { get; set; }
        
        private decimal _storageItemRetailPrice = 0;

        private decimal StorageItemRetailPrice
        {
            get => _storageItemRetailPrice;
            set { 
                OnStorageItemRetailPriceChanged.InvokeAsync(value);
                _storageItemRetailPrice = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}