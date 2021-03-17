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
    public partial class SelectUnit
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public Guid UnitId { get; set; }
        [Parameter] public EventCallback<Guid> UnitIdChanged { get; set; }
        [Parameter] public bool CanCreate { get; set; }
        
        private Guid SelectedUnitId 
        { 
            get => UnitId;
            set
            {
                Console.WriteLine(value.ToString());
                UnitId = value;
                UnitIdChanged.InvokeAsync(value);
            }
        }
        private List<UnitViewModel> Units { get; set; }
        private bool _loading = true;
        private bool _isNewUnitDisplay = false;
        
        protected override async Task OnInitializedAsync()
        {
            var unitsRequest = new GetAllUnitsHttpQuery() {InstanceId = await SessionProvider.GetCurrentInstanceId()};
            Units = (await new GetAllUnitsRequest(RequestManager, HttpClient, unitsRequest).Send()).Data.ToList();
            var unitId = await SessionProvider.GetCurrentUnitId();
            if (unitId != Guid.Empty)
                SelectedUnitId = unitId;
            _loading = false;
        }
    }
}