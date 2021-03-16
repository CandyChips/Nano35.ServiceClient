using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class CreateArticleForm :
        ComponentBase
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        
        private bool _loading = true;
        private CreateArticleHttpBody _model = new CreateArticleHttpBody();
        
        protected override async Task OnInitializedAsync()
        {
            _model.InstanceId = await SessionProvider.GetCurrentInstanceId();
            _model.NewId = Guid.NewGuid();
            _loading = false;
        }

        private async void HandleValidSubmit()
        {
            await new CreateArticleRequest(RequestManager, HttpClient, _model).Send();
        }
    }
}