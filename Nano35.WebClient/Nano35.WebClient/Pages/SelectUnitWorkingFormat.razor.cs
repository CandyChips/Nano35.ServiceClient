using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectUnitWorkingFormat
    {
        [Parameter] public EventCallback<string> OnSelectedUnitsTypeChanged { get; set; }
        
        private string _selectedUnitWorkingFormat;
        private string SelectedUnitWorkingFormat { get => _selectedUnitWorkingFormat; set { _selectedUnitWorkingFormat = value; OnUnitsTypeChanged(); } }

        private bool _loading = true;
        
        protected override async Task OnInitializedAsync()
        {
            _loading = false;
        }

        private void OnUnitsTypeChanged()
        {
            OnSelectedUnitsTypeChanged.InvokeAsync(_selectedUnitWorkingFormat);
        }
    }
}