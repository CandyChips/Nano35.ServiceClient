using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectStorageItem : ComponentBase
    {
        private string StorageItem { get; set; }
        private ModalNewStorageItem modalNewStorageItem { get; set; }
        
        private void ShowModalNewComing()
        {
            this.modalNewStorageItem.Show();
        }
    }
        
}