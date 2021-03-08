using Microsoft.AspNetCore.Components;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticle : ComponentBase
    {
        private string Article { get; set; }
        private ModalNewArticle modalNewArticle { get; set; }
        
        private void ShowModalNewArticle()
        {
            this.modalNewArticle.Show();
        }
    }
}