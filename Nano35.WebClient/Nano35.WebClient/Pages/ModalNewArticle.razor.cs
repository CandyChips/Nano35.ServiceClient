using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewArticle :
        ComponentBase
    {
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IArticlesService ArticlesService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback OnHideModalNewArticle { get; set; }
        
        private bool _loading = true;
        private string _error = "";
        private bool _serverAvailable = false;

        private CreateArticleHttpBody _model = new CreateArticleHttpBody();
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _model.InstanceId = await SessionProvider.GetCurrentInstanceId();
            _model.NewId = Guid.NewGuid();
            _loading = false;
        }

        private void CurrentArticleCategoryChanged(Guid newId)
        {
            _model.CategoryId = newId;
        }

        private async void HandleValidSubmit()
        {
            await ArticlesService.CreateArticle(_model);
            HideModalNewArticle();
        }

       
        private void HideModalNewArticle()
        {
            OnHideModalNewArticle.InvokeAsync();
        }
    }
}