using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Coming
    {
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        
        [Inject] 
        private IComingsService _comingsService { get; set; }
        
        [Inject]
        private ISessionProvider _sessionProvider { get; set; }

        private IEnumerable<ComingViewModel> _data;

        public ModalNewComing ModalNewComing { get; set; }
        
        private bool _serverAvailable = false;
        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.StorageServer);
            _data = (await _comingsService.GetAllComings(await _sessionProvider.GetCurrentInstanceId())).Data;
            _loading = false;
        }
        
        private void ShowModalNewComing()
        {
            this.ModalNewComing.Show();
        }
        
    }
}