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
    public partial class SelectArticle : 
        ComponentBase
    {
        [Parameter] public Guid SelectedArticlesId { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        
        private List<ArticleViewModel> Articles { get; set; }
        private Guid _selectedArticlesId;
        private bool _isLoading = true;
        private bool _isNewArticleDisplay = false;
        
        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllArticlesHttpQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId()};
            Articles = (await new GetAllArticlesRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
            _isLoading = false;
        }
    }
}