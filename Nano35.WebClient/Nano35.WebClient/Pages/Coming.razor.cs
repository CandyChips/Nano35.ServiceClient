using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Coming :
        ComponentBase
    {
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IComingsService ComingsService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }

        private IEnumerable<ComingViewModel> _data;
        private bool _isNewComingDisplay = false;
        private bool _serverAvailable = false;
        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.StorageServer);
            _data = (await ComingsService.GetAllComings(await SessionProvider.GetCurrentInstanceId())).Data;
            _loading = false;
        }

        private void ShowModalNewComing() => _isNewComingDisplay = true;
        private void HideModalNewComing() => _isNewComingDisplay = false;
        
    }
}