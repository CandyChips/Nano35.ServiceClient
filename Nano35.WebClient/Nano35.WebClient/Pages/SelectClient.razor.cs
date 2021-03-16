using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectClient
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public Guid SelectedClientId { get; set; }
        
        private List<ClientViewModel> Clients { get; set; }
        private bool _loading = true;
        private bool _isNewClientDisplay = false;

        protected override async Task OnInitializedAsync()
        {
            var request = new GetAllClientsHttpQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId()};
            Clients = (await new GetAllClientsRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
            _loading = false;
        }
    }
}