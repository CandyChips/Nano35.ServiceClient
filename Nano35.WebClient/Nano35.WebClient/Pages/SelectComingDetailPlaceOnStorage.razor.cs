using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectComingDetailPlaceOnStorage
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<string> OnComingDetailPlaceOnStorageChanged { get; set; }
        
        private List<string> _comingDetailPlacesOnStorage = new List<string>();
        private string _comingDetailPlaceOnStorage = "";

        private string ComingDetailPlaceOnStorage
        {
            get => _comingDetailPlaceOnStorage;
            set { 
                OnComingDetailPlaceOnStorageChanged.InvokeAsync(value);
                _comingDetailPlaceOnStorage = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}