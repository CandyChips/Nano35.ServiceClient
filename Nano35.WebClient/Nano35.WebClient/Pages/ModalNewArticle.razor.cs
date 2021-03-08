using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewArticle
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        private bool Loading = true;
        private string _error = "";
        private bool _serverAvailable = false;
        public bool Display { get; private set; }

        private CreateArticleHttpBody _model = new CreateArticleHttpBody();

        private List<ArticleCategoryViewModel> _categories = new List<ArticleCategoryViewModel>();
        
        [Inject] 
        private IRequestManager RequestManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            Loading = false;
        }

        private async void HandleValidSubmit()
        {
        }
        
        public void Show()
        {
            this.Display = true;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Hide()
        {
            this.Display = false;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Create()
        {
        }
    }
}