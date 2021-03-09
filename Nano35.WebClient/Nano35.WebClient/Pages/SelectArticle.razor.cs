using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticle : ComponentBase
    {
        [Parameter] public EventCallback<Guid> OnSelectedArticleChanged { get; set; }
        [Inject] private IArticlesService ArticlesService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        
        private List<ArticleViewModel> Articles { get; set; }
        private Guid _selectedArticlesId;
        private Guid SelectedArticlesId { get => _selectedArticlesId; set { _selectedArticlesId = value; OnArticleChanged(); } }

        private bool _isLoading = true;
        private bool _isNewArticleDisplay = false;
        
        protected override async Task OnInitializedAsync()
        {            
            Articles = (await ArticlesService.GetAllArticles(await SessionProvider.GetCurrentInstanceId())).Data.ToList();
            _isLoading = false;
        }

        private async Task OnArticleChanged() => 
            await OnSelectedArticleChanged.InvokeAsync(_selectedArticlesId);
        private void ShowModalNewArticle() => 
            _isNewArticleDisplay = true;
        private void HideModalNewArticle() => 
            _isNewArticleDisplay = false;
    }
}