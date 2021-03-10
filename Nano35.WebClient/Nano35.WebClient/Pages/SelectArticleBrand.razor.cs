using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticleBrand
    {
        [Inject] private IArticlesService ArticlesService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<string> OnArticleBrandChanged { get; set; }
        
        private List<string> _brands = new List<string>();
        private string _brand = "";

        private string Brand
        {
            get => _brand;
            set { 
                OnArticleBrandChanged.InvokeAsync(value);
                _brand = value;
            }
        }
        
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _brands = (await ArticlesService.GetAllBrands(await SessionProvider.GetCurrentInstanceId(), Guid.Empty)).Data.ToList();
            _isLoading = false;
        }
    }
}