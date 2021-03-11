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
    public partial class SelectArticleBrand
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public EventCallback<string> OnArticleBrandChanged { get; set; }
        
        private List<string> _brands = new List<string>();
        private string _brand = "";

        private string Brand
        {
            get => _brand;
            set { 
                OnArticleBrandChanged.InvokeAsync(value);
                _brand = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            var request = new GetAllArticlesBrandsHttpQuery() { InstanceId = await SessionProvider.GetCurrentInstanceId(), CategoryId = Guid.Empty};
            _brands = (await new GetAllArticlesBrandsRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
        }
    }
}