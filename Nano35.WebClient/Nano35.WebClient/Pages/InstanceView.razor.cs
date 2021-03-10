using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class InstanceView :
        ComponentBase
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            if (!await SessionProvider.IsCurrentSessionIdExist())
                NavigationManager.NavigateTo("/instances");
            if(!await RequestManager.HealthCheck(RequestManager.InstanceServer))
                NavigationManager.NavigateTo("/instances");
        }
    }
}