using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Workers
    {
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private IInstanceService InstanceService { get; set; }
        [Inject] private IWorkerService WorkerService { get; set; }
        
        private bool _loading = true;
        private bool _isNewWorkerDisplay = false;
        private IEnumerable<WorkerViewModel> _data;
        
        protected override async Task OnInitializedAsync()
        {
            _data = (await WorkerService.GetAllWorkers(InstanceService.GetCurrentInstance().Id)).Data;
            _loading = false;
        }

        private void ShowModalNewWorker() =>
            _isNewWorkerDisplay = true;

        private void HideModalNewWorker() =>
            _isNewWorkerDisplay = false;
    }
}