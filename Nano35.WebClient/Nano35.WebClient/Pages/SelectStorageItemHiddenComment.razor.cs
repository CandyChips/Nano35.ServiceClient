using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItemHiddenComment
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<string> OnStorageItemHiddenCommentChanged { get; set; }
        
        private string _storageItemHiddenComment = "";

        private string StorageItemHiddenComment
        {
            get => _storageItemHiddenComment;
            set { 
                OnStorageItemHiddenCommentChanged.InvokeAsync(value);
                _storageItemHiddenComment = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _isLoading = false;
        }
    }
}