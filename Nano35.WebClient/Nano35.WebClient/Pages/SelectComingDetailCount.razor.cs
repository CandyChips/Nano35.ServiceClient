using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectComingDetailCount
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<int> OnComingDetailCountChanged { get; set; }
        
        private int _comingDetailCount = 0;

        private int ComingDetailCount
        {
            get => _comingDetailCount;
            set { 
                OnComingDetailCountChanged.InvokeAsync(value);
                _comingDetailCount = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}