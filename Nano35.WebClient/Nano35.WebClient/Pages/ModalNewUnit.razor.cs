using System;
using System.Collections;
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
    public partial class ModalNewUnit : ComponentBase
    {
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IUnitService UnitService { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Parameter] public EventCallback OnHideModalNewUnit { get; set; }
        
        private CreateUnitHttpBody _model = new CreateUnitHttpBody();
        private bool _loading = true;
        private string _error = string.Empty;
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            _loading = false;
        }

        private void HandleValidSubmit()
        {
            
        }
        
        private void HideModalNewUnit()
        {
            OnHideModalNewUnit.InvokeAsync();
        }
        
        private void UnitsTypeIdChanged(Guid unitTypeId) => _model.UnitTypeId = unitTypeId;
        private void UnitsNameChanged(string name) => _model.Name = name;
        private void UnitsAddressChanged(string address) => _model.Address = address;
        private void UnitsPhoneChanged(string phone) => _model.Phone = phone;
        private void UnitsWorkingFormatChanged(string workingFormat) => _model.WorkingFormat = workingFormat;

        private async void Create()
        {
            _model.Id = Guid.NewGuid();
            _model.InstanceId = InstanceService.GetCurrentInstance().Id;
            await new CreateUnitRequest(RequestManager, HttpClient, _model).Send();
        }
    }
}