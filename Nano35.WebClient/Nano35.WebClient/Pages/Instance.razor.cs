using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Instance
    {
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject] 
        private IInstanceService _instanceService { get; set; }
        
        private bool _serverAvailable = false;
        private bool _loading = true;
        private List<InstanceViewModel> _data = new List<InstanceViewModel>();
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await _requestManager.HealthCheck(_requestManager.InstanceServer);
            _data = await _instanceService.GetInstanceById();
            _loading = false;
        }
    }
}