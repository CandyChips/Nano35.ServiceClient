using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class ModalNewComingDetail : ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private IClientService ClientService { get; set; }
        [Inject] private IUnitService UnitService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback OnHideModalNewComingDetail { get; set; }
        
        private IEnumerable<IClientViewModel> Clients { get; set; }
        private IEnumerable<IUnitViewModel> Units { get; set; }
        
        private CreateComingHttpBody _model = new CreateComingHttpBody();
        private List<CreateComingDetailViewModel> _details = new List<CreateComingDetailViewModel>();
        private bool _loading = true;
        private string _error = "";
        private bool _serverAvailable = false;

        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.IdentityServer);
            Clients = (await ClientService.GetAllClients(await SessionProvider.GetCurrentInstanceId())).Data;
            Units = (await UnitService.GetAllUnit(await SessionProvider.GetCurrentInstanceId())).Data;
            _loading = false;
        }

        private void HandleValidSubmit()
        {
            HideModalNewComingDetail();
        }

       
        private void HideModalNewComingDetail() =>
            OnHideModalNewComingDetail.InvokeAsync();
    }
}