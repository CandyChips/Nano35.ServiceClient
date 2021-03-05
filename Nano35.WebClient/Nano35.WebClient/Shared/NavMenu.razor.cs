using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Shared
{
    public partial class NavMenu
    {
        [Inject] 
        private IInstanceService _instanceService { get; set; }
        
        public string OrgName { get; set; }

        protected override async Task OnInitializedAsync()
        {
            OrgName = _instanceService.GetCurrentInstance().OrgName;
        }
    }
}