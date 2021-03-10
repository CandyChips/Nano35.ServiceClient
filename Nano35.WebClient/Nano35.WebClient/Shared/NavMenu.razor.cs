using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Shared
{
    public partial class NavMenu
    {
        [Inject] private IInstanceService InstanceService { get; set; }

        private string OrgName { get; set; }

        protected override void OnInitialized()
        {
            OrgName = InstanceService.GetCurrentInstance().OrgName;
        }
    }
}