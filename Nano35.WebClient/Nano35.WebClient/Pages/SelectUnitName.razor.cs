using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectUnitName
    {
        [Parameter] public EventCallback<string> OnSelectedUnitNameChanged { get; set; }
        
        private string _selectedUnitName;
        private string SelectedUnitName { get => _selectedUnitName; set { _selectedUnitName = value; OnUnitNameChanged(); } }

        private bool _loading = true;
        
        protected override async Task OnInitializedAsync()
        {
            _loading = false;
        }

        private void OnUnitNameChanged()
        {
            OnSelectedUnitNameChanged.InvokeAsync(_selectedUnitName);
        }
    }
}