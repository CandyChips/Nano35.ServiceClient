﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.storage;
using Nano35.WebClient.Services;

namespace Nano35.WebClient.Pages
{
    public partial class SelectArticleCategory
    {
        [Inject] private ISessionProvider SessionProvider { get; set; }
        [Inject] private IRequestManager RequestManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public EventCallback<Guid> OnSelectedArticleCategoryChanged { get; set; }
        
        private List<ArticleCategoryViewModel> _categories = new List<ArticleCategoryViewModel>();
        private List<ArticleCategoryViewModel> _selectedCategories = new List<ArticleCategoryViewModel>();
        private string _name = "";
        private bool _isLoading = true;
        
        protected override async Task OnInitializedAsync()
        {            
            var request = new GetAllArticlesCategoriesHttpQuery() { InstanceId = await SessionProvider.GetCurrentInstanceId(), ParentId = Guid.Empty};
            _categories = (await new GetAllArticleCategoriesRequest(RequestManager, HttpClient, request).Send()).Data.ToList();

            _isLoading = false;
        }

        private async Task OnAddCategory(ArticleCategoryViewModel selected)
        {
            _isLoading = true;
            _categories.Clear();
            _selectedCategories.Add(selected);
             
            var request = new GetAllArticlesCategoriesHttpQuery() { InstanceId = await SessionProvider.GetCurrentInstanceId(), ParentId = selected.Id};
            _categories = (await new GetAllArticleCategoriesRequest(RequestManager, HttpClient, request).Send()).Data.ToList();
            
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
            await new CreateCategoryRequest(RequestManager, HttpClient, body).Send();
            
            _selectedCategories.Add(new ArticleCategoryViewModel() {Id = body.NewId, Name = body.Name, ParentCategoryId = body.ParentCategoryId});
            
            var request = new GetAllArticlesCategoriesHttpQuery() { InstanceId = await SessionProvider.GetCurrentInstanceId(), ParentId = _selectedCategories.Last().Id};
            _categories = (await new GetAllArticleCategoriesRequest(RequestManager, HttpClient, request).Send()).Data.ToList();

            _isLoading = false;
        }

        private async Task OnRemoveSelectedCategory(int index)
        {
            _isLoading = true;
            _categories.Clear();
            _selectedCategories.RemoveRange(index, _selectedCategories.Count - index);
            
            var request = new GetAllArticlesCategoriesHttpQuery() { InstanceId = await SessionProvider.GetCurrentInstanceId(), ParentId = _selectedCategories.Last().Id};
            _categories = (await new GetAllArticleCategoriesRequest(RequestManager, HttpClient, request).Send()).Data.ToList();

            _isLoading = false;
            StateHasChanged();
        }
    }
}