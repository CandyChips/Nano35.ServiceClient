using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectUnitPhone
    {
        [Parameter] public EventCallback<string> OnSelectedUnitPhoneChanged { get; set; }
        
        private string _selectedUnitPhone;
        private string SelectedUnitPhone { get => _selectedUnitPhone; set { _selectedUnitPhone = value; OnUnitPhoneChanged(); } }

        private bool _loading = true;
        
        protected override async Task OnInitializedAsync()
        {
            _loading = false;
        }

        private void OnUnitPhoneChanged()
        {
            OnSelectedUnitPhoneChanged.InvokeAsync(_selectedUnitPhone);
        }
    }
}