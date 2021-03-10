using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Nano35.HttpContext.storage;
using Newtonsoft.Json;

namespace Nano35.WebClient.Services
{
    public interface IArticlesService
    {
        Task<GetAllArticlesSuccessHttpResponse> GetAllArticles(Guid instanceId);
        Task<GetAllArticleCategoriesSuccessHttpResponse> GetAllCategories(Guid instanceId);
        Task<GetAllArticleBrandsSuccessHttpResponse> GetAllBrands(Guid instanceId, Guid categoryId);
        Task<GetAllArticleModelsSuccessHttpResponse> GetAllModels(Guid instanceId, Guid categoryId);
        Task<GetAllArticleCategoriesSuccessHttpResponse> GetAllSubCategories(Guid rootId);
        Task<CreateCategorySuccessHttpResponse> CreateCategory(CreateCategoryHttpBody body);
        Task<CreateArticleSuccessHttpResponse> CreateArticle(CreateArticleHttpBody body);
    }
    
    public class ArticlesService :
        IArticlesService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestManager _requestManager;

        public ArticlesService(
            HttpClient httpClient,
            IRequestManager requestManager)
        {
            _httpClient = httpClient;
            _requestManager = requestManager;
        }
        
        public async Task<GetAllArticlesSuccessHttpResponse> GetAllArticles(Guid instanceId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5003/Articles/GetAllArticles?InstanceId={instanceId}");
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllArticlesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<GetAllArticlesErrorHttpResponse>())?.Message);
        }

        public async Task<GetAllArticleCategoriesSuccessHttpResponse> GetAllCategories(Guid instanceId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5003/Category/GetAllArticleCategories?InstanceId={instanceId}");

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllArticleCategoriesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<GetAllArticleCategoriesErrorHttpResponse>())?.Message);
        }

        public async Task<GetAllArticleBrandsSuccessHttpResponse> GetAllBrands(Guid instanceId, Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5003/Articles/GetAllArticleBrands?InstanceId={instanceId}&CategoryId={categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllArticleBrandsSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<GetAllArticleBrandsErrorHttpResponse>())?.Message);
        }

        public async Task<GetAllArticleModelsSuccessHttpResponse> GetAllModels(Guid instanceId, Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5003/Articles/GetAllArticleModels?InstanceId={instanceId}&CategoryId={categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllArticleModelsSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<GetAllArticleModelsErrorHttpResponse>())?.Message);
        }

        public async Task<GetAllArticleCategoriesSuccessHttpResponse> GetAllSubCategories(Guid rootId)
        {                
            var response = await _httpClient.GetAsync($"http://localhost:5003/Category/GetAllArticleCategories?parentId={rootId}");

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<GetAllArticleCategoriesSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<GetAllArticleCategoriesErrorHttpResponse>())?.Message);

        }

        public async Task<CreateCategorySuccessHttpResponse> CreateCategory(CreateCategoryHttpBody body)
        {
            var response = await _httpClient.PostAsJsonAsync($"http://localhost:5003/Category/CreateCategory", body);

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<CreateCategorySuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<CreateCategoryErrorHttpResponse>())?.Error);
        }

        public async Task<CreateArticleSuccessHttpResponse> CreateArticle(CreateArticleHttpBody body)
        {
            var response = await _httpClient.PostAsJsonAsync($"http://localhost:5003/Articles/CreateArticle", body);

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<CreateArticleSuccessHttpResponse>());
            }
            throw new Exception((await response.Content.ReadFromJsonAsync<CreateArticleErrorHttpResponse>())?.Error);
        }
    }
}