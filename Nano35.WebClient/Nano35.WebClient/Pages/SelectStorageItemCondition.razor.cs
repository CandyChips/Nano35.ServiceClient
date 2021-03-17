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
    public partial class SelectStorageItemCondition :
        ComponentBase
    {
        [Parameter] public Guid SelectedConditionId { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }

        private List<StorageItemConditionViewModel> _conditions;
        private bool _isLoading = true;
        
        
        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllStorageItemConditionsHttpQuery();
            _conditions = (await new GetAllStorageItemConditionsRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
            _isLoading = false;
        }
    }
}