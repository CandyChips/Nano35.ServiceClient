using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticleInfo
    {
        [Parameter] public EventCallback<string> OnArticleInfoChanged { get; set; }
        
        private string _info = "";

        private string Info
        {
            get => _info;
            set { 
                OnArticleInfoChanged.InvokeAsync(value);
                _info = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}