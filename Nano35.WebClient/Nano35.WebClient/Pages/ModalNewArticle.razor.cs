using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewArticle :
        ComponentBase
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public EventCallback OnHideModalNewArticle { get; set; }
        
        private bool _loading = true;
        private bool _serverAvailable = false;
        private CreateArticleHttpBody _model = new CreateArticleHttpBody();
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _model.InstanceId = await SessionProvider.GetCurrentInstanceId();
            _model.NewId = Guid.NewGuid();
            _loading = false;
        }

        private void CurrentArticleCategoryChanged(Guid newId) => _model.CategoryId = newId;
        private void CurrentArticleBrandChanged(string brand) => _model.Brand = brand;
        private void CurrentArticleModelChanged(string model) => _model.Model = model;
        private void ArticleInfoChanged(string info) => _model.Info = info;
        private void CurrentArticlesSpecsChanged(List<SpecHttpContext> specs) => _model.Specs = specs;
        
        private async void HandleValidSubmit()
        {
            await new CreateArticleRequest(RequestManager, HttpClient, _model).Send();
            HideModalNewArticle();
        }

       
        private void HideModalNewArticle()
        {
            OnHideModalNewArticle.InvokeAsync();
        }
    }
}