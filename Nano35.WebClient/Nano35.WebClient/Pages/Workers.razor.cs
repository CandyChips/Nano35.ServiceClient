﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Instance.Models;
using Nano35.HttpContext.instance;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class Workers
    {
        [Inject] 
        private IRequestManager _requestManager { get; set; }
        [Inject]
        private IInstanceService _instanceService { get; set; }
        [Inject]
        private IWorkerService _workerService { get; set; }
        public ModalNewWorker ModalNewWorker { get; set; }

        private bool _loading = true;
        private IEnumerable<WorkerViewModel> _data;
        protected override async Task OnInitializedAsync()
        {
            _data = (await _workerService.GetAllWorkers(_instanceService.GetCurrentInstance().Id)).Data;
            _loading = false;
        }
        
        private void ShowModalNewWorker()
        {
            this.ModalNewWorker.Show();
        }
    }
}