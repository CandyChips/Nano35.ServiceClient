using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectComingDetailPlaceOnStorage
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public Guid UnitId { get; set; }
        [Parameter] public Guid StorageItemId { get; set; }
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
        private Guid _comingDetailStorageItemId { get; set; }

        private Guid ComingDetailStorageItemId
        {
            get => _comingDetailStorageItemId;
            set
            {
                _comingDetailStorageItemId = value;
                UpdatePlacesOnStorage();
            }
        }

        // ToDo move to add coming detail component
        private async Task UpdatePlacesOnStorage()
        {
            if (StorageItemId != Guid.Empty)
            {
                var request = new GetAllPlacesOnStorageHttpContext() {UnitId = UnitId, StorageItemId = StorageItemId};
                _comingDetailPlacesOnStorage = (await new GetAllPlacesOnStorageRequest(RequestManager, HttpClient, request).Send()).Data.Select(a => $"{a.Name}: {a.Count}").ToList();
            }
        } 
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {
            _isLoading = false;
        }
    }
}