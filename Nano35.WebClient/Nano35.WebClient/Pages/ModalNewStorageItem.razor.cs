using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewStorageItem : ComponentBase
    {        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        private bool Loading = true;
        private string Error = "";
        private bool ServerAvailable = false;
        public bool Display { get; private set; }

        private CreateStorageItemHttpBody _model = new CreateStorageItemHttpBody();
        private List<StorageItemConditionViewModel> conditions = new List<StorageItemConditionViewModel>();
        
        [Inject] 
        private IRequestManager RequestManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            ServerAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
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