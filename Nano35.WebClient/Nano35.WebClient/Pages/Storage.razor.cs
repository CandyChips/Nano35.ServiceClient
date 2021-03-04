using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Storage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject]
        private IInstanceService _instanceService { get; set; }
    }
}