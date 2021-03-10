using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticleCategory
    {
        [Inject] private IArticlesService ArticlesService { get; set; }
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Parameter] public EventCallback<Guid> OnSelectedArticleCategoryChanged { get; set; }
        
        private List<ArticleCategoryViewModel> _categories = new List<ArticleCategoryViewModel>();
        private List<ArticleCategoryViewModel> _selectedCategories = new List<ArticleCategoryViewModel>();
        private string _name = "";
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            _categories = (await ArticlesService.GetAllCategories(await SessionProvider.GetCurrentInstanceId())).Data.ToList();
            _isLoading = false;
        }

        private async Task OnAddCategory(ArticleCategoryViewModel selected)
        {
            _isLoading = true;
            _categories.Clear();
            _selectedCategories.Add(selected);
            _categories = (await ArticlesService.GetAllSubCategories(_selectedCategories.Last().Id)).Data.ToList();
            await OnSelectedArticleCategoryChanged.InvokeAsync(selected.Id);
            _isLoading = false;
        }

        private async Task OnCreateCategory()
        {
            _isLoading = true;
            _categories.Clear();
            var body = new CreateCategoryHttpBody()
            {
                Name = _name,
                InstanceId = await SessionProvider.GetCurrentInstanceId(),
                NewId = Guid.NewGuid(),
                ParentCategoryId = _selectedCategories.Count == 0 ? Guid.Empty : _selectedCategories.Last().Id
            };
            _selectedCategories.Add(new ArticleCategoryViewModel() {Id = body.NewId, Name = body.Name, ParentCategoryId = body.ParentCategoryId});
            await ArticlesService.CreateCategory(body);
            _categories = (await ArticlesService.GetAllSubCategories(body.NewId)).Data.ToList();
            _isLoading = false;
        }

        private async Task OnRemoveSelectedCategory(int index)
        {
            _isLoading = true;
            _categories.Clear();
            _selectedCategories.RemoveRange(index, _selectedCategories.Count - index);
            _categories = (await ArticlesService.GetAllSubCategories(_selectedCategories.Last().Id)).Data.ToList();
            _isLoading = false;
            StateHasChanged();
        }
    }
}