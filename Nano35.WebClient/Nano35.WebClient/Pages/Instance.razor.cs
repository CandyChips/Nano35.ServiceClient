using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Instance :
        ComponentBase
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            NavigationManager.NavigateTo("/instance-view");
            if (!await SessionProvider.IsCurrentSessionIdExist())
                NavigationManager.NavigateTo("/instances");
        }
    }
}