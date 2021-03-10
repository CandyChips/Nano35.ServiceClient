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
    public partial class SelectArticleModel
    {
        [Inject] private IArticlesService ArticlesService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public EventCallback<string> OnArticleModelChanged { get; set; }
        
        private List<string> _models = new List<string>();
        private string _model = "";

        private string Model
        {
            get => _model;
            set { 
                OnArticleModelChanged.InvokeAsync(value);
                _model = value;
            }
        }
        
        
        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllArticleModelsHttpQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId(), CategoryId = Guid.Empty};
            _models = (await new GetAllArticlesModelsRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
        }
    }
}