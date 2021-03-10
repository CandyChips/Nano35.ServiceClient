using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItemComment
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<string> OnStorageItemCommentChanged { get; set; }
        
        private string _storageItemComment = "";

        private string StorageItemComment
        {
            get => _storageItemComment;
            set { 
                OnStorageItemCommentChanged.InvokeAsync(value);
                _storageItemComment = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}