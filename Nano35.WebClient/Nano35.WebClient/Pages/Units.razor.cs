using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Units
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private IUnitService UnitService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }

        private bool _isNewUnitDisplay;
        private bool _serverAvailable;
        private bool _loading = true;
        private IEnumerable<UnitViewModel> _data;
        protected override async Task OnInitializedAsync()
        {
            _serverAvailable = await RequestManager.HealthCheck(RequestManager.InstanceServer);
            if(!_serverAvailable)
                NavigationManager.NavigateTo("/instances");
            if (!await SessionProvider.IsCurrentSessionIdExist())
                NavigationManager.NavigateTo("/instances");
            _data = (await UnitService.GetAllUnit(InstanceService.GetCurrentInstance().Id)).Data;
            _loading = false;
        }
        private void ShowModalNewUnit() => _isNewUnitDisplay = true;
        private void HideModalNewUnit() => _isNewUnitDisplay = false;
    }
}