using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [Inject] private IUnitService UnitService { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Parameter] public EventCallback OnHideModalNewUnit { get; set; }
        
        private List<UnitTypeViewModel> Types { get; set; }
        private CreateUnitHttpBody _model = new CreateUnitHttpBody();
        private bool _loading = true;
        private string _error = "";
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            Types = (await UnitService.GetAllUnitTypes()).Data.ToList();
            _loading = false;
        }

        private void HandleValidSubmit()
        {
            
        }
        
        private void HideModalNewUnit()
        {
            OnHideModalNewUnit.InvokeAsync();
        }

        private void Create()
        {
            _model.Id = Guid.NewGuid();
            _model.InstanceId = InstanceService.GetCurrentInstance().Id;
            UnitService.CreateUnit(_model);
        }
    }
}