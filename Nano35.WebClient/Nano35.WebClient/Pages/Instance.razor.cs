using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Instance
    {
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        private bool _loading = true;
        private IInstanceViewModel _data;
        protected override async Task OnInitializedAsync()
        { 
            NavigationManager.NavigateTo("/instance-view");
        }
    }
}