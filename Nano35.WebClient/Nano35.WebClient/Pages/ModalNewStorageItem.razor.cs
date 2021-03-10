using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewStorageItem : ComponentBase
    {        
        [Inject] private IRequestManager RequestManager { get; set; }
        [Parameter] public EventCallback OnHideModalNewStorageItem { get; set; }
        
        private bool _loading = true;
        private bool _serverAvailable = false;
        private CreateStorageItemHttpBody _model = new CreateStorageItemHttpBody();
        private List<StorageItemConditionViewModel> _conditions = new List<StorageItemConditionViewModel>();
        
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _loading = false;
        }

        private void OnSelectedStorageItemConditionChanged(Guid conditionId) => _model.ConditionId = conditionId;
        private void OnSelectedArticleChanged(Guid articleId) => _model.ArticleId = articleId;
        private void OnStorageItemCommentChanged(string comment) => _model.Comment = comment;
        private void OnStorageItemHiddenCommentChanged(string hiddenComment) => _model.HiddenComment = hiddenComment;
        private void OnStorageItemPurchasePriceChanged(decimal purchasePrice) => _model.PurchasePrice = purchasePrice;
        private void OnStorageItemRetailPriceChanged(decimal retailPrice) => _model.RetailPrice = retailPrice;

        private void Create()
        {
            //throw new Exception(JsonConvert.SerializeObject(_model));
            HideModalNewStorageItem();
        }

       
        private void HideModalNewStorageItem()
        {
            OnHideModalNewStorageItem.InvokeAsync();
        }
    }
}