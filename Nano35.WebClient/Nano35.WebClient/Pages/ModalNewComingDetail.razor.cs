using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.Contracts.Storage.Models;
using Nano35.HttpContext.instance;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewComingDetail :
        ComponentBase
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        
        [Parameter] public EventCallback OnHideModalNewComingDetail { get; set; }
        [Parameter] public Guid UnitId { get; set; }
        [Parameter] public EventCallback<CreateComingDetailViewModel> OnAddNewComingDetail { get; set; }
        
        private CreateComingDetailViewModel _model = new CreateComingDetailViewModel();
        private bool _loading = true;
        private string _error = string.Empty;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _model.Count = 1;
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _loading = false;
        }

        private void HandleValidSubmit()
        {
            OnAddNewComingDetail.InvokeAsync(_model);
            HideModalNewComingDetail();
        }

        private void OnSelectedStorageItemChanged(Guid storageItemId) => _model.StorageItemId = storageItemId;
        private void OnComingDetailPlaceOnStorageChanged(string placeOnStorage) => _model.PlaceOnStorage = placeOnStorage;
        private void OnComingDetailCountChanged(int count) => _model.Count = count;
        private void OnComingDetailPriceChanged(int price) => _model.Price = price;
        
       
        private void HideModalNewComingDetail() =>
            OnHideModalNewComingDetail.InvokeAsync();
    }
}