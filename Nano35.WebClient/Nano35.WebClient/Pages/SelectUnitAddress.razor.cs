using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectUnitAddress
    {
        [Parameter] public EventCallback<string> OnSelectedUnitAddressChanged { get; set; }
        
        private string _selectedUnitAddress;
        private string SelectedUnitAddress { get => _selectedUnitAddress; set { _selectedUnitAddress = value; OnUnitAddressChanged(); } }

        private bool _loading = true;
        
        protected override async Task OnInitializedAsync()
        {
            _loading = false;
        }

        private void OnUnitAddressChanged()
        {
            OnSelectedUnitAddressChanged.InvokeAsync(_selectedUnitAddress);
        }
    }
}