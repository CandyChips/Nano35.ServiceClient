using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticleModel
    {
        [Inject] private IArticlesService ArticlesService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<string> OnArticleModelChanged { get; set; }
        
        private List<string> _models = new List<string>();
        private string _model = "";

        private string Model
        {
            get => _model;
            set { 
                OnArticleModelChanged.InvokeAsync(value);
                _model = value;
            }
        }
        
        
        protected override async Task OnInitializedAsync()
        {            
            _models = (await ArticlesService.GetAllModels(await SessionProvider.GetCurrentInstanceId(), Guid.Empty)).Data.ToList();
        }
    }
}