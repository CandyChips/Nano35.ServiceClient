using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewComing : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject] 
        private IRequestManager RequestManager { get; set; }
        [Inject] 
        private IInstanceService InstanceService { get; set; }
        [Inject] 
        private IClientService ClientService { get; set; }
        [Inject] 
        private IUnitService UnitService { get; set; }
        [Inject] 
        private ISessionProvider SessionProvider { get; set; }
        
        private IEnumerable<IClientViewModel> Clients { get; set; }
        private IEnumerable<IUnitViewModel> Units { get; set; }
        
        private CreateComingHttpBody _model = new CreateComingHttpBody();
        private List<CreateComingDetailViewModel> _details = new List<CreateComingDetailViewModel>();
        private bool _loading = true;
        private string _error = "";
        private bool _serverAvailable = false;

        private ModalNewComingDetail modalNewComingDetail = new ModalNewComingDetail();
        
        public bool Display { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            Clients = (await ClientService.GetAllClients(await SessionProvider.GetCurrentInstanceId())).Data;
            Units = (await UnitService.GetAllUnit(await SessionProvider.GetCurrentInstanceId())).Data;
            _loading = false;
        }

        private async void HandleValidSubmit()
        {
        }
        
        public void Show()
        {
            this.Display = true;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Hide()
        {
            this.Display = false;
            this.InvokeAsync(this.StateHasChanged);
        }

        public void Create()
        {
           // model.NewId = Guid.NewGuid();
           // model.InstanceId = _instanceService.GetCurrentInstance().Id;
           // _clientservice.CreateClient(model);
        }
        
        private void ShowModalNewComingDetail()
        {
            this.modalNewComingDetail.Show();
        }
    }
}