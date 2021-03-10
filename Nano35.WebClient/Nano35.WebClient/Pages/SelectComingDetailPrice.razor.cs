using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectComingDetailPrice
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<int> OnComingDetailPriceChanged { get; set; }
        
        private int _comingDetailPrice = 0;

        private int ComingDetailPrice
        {
            get => _comingDetailPrice;
            set { 
                OnComingDetailPriceChanged.InvokeAsync(value);
                _comingDetailPrice = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}