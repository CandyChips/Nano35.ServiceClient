using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nano35.WebClient.Services;

namespace WebApplication2.Pages
{
    public partial class Instance
    {
        [Inject]
        private IRequestManager _requestManager { get; set; }

        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        private HttpClient _httpClient { get; set; }
        
        async Task GetAllInstances()
        {
            var response = await _httpClient.GetAsync( $"{_requestManager.InstanceServer}/Instances/GetAllInstances?UserId={_authService.User.Id}");
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
            }
            
        }
    }
}