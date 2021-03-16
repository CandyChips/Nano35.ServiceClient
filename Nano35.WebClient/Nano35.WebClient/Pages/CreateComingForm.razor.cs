using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class CreateComingForm : 
        ComponentBase
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback OnHideModalNewComing { get; set; }
        
        
        private CreateComingHttpBody _model = new CreateComingHttpBody();
        private List<CreateComingDetailViewModel> _details = new List<CreateComingDetailViewModel>();
        private bool _loading = true;
        private string _error = string.Empty;
        private bool _serverAvailable = false;
        private bool _isNewComingDetailDisplay = false;
        private bool _isNewUnitDisplay = false;


        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _details = new List<CreateComingDetailViewModel>();
            _model.InstanceId = await SessionProvider.GetCurrentInstanceId();
            var unitId = await SessionProvider.GetCurrentInstanceId();
            if (unitId != Guid.Empty)
            {
                ComingUnitChanged(unitId);
            }
            _model.NewId = Guid.NewGuid();
            _loading = false;
        }

        private async void Create()
        {
            _model.Details = _details;
            await new CreateComingRequest(RequestManager, HttpClient, _model).Send();
        }
        
        private void HideModalNewComing() =>
            OnHideModalNewComing.InvokeAsync();

        private void AddComingDetail(CreateComingDetailViewModel model)
        {
            _details.Add(model);
            StateHasChanged();
        }
        
        private void ComingUnitChanged(Guid unitId) => _model.UnitId = unitId;
        private void ComingClientChanged(Guid clientId) => _model.ClientId = clientId;

    }
}