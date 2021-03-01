using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nano35.WebClient.Services
{
    public interface IRequestManager
    {
        string IdentityServer { get; }
        string InstanceServer { get; }
        string StorageServer { get; }
        string RepairOrdersServer { get; }
        string FileServer { get; }
        Task<bool> HealthCheck(string serverUrl);
    }

    public class ClusterRequestManager :
        IRequestManager
    {
        private readonly HttpClient _httpClient;

        public ClusterRequestManager(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string IdentityServer => "http://192.168.100.210:30001";

        public string InstanceServer => "http://192.168.100.210:30002";

        public string StorageServer => "http://192.168.100.210:30003";

        public string RepairOrdersServer => "http://192.168.100.210:30004";

        public string FileServer => "http://192.168.100.210:30005";

        public async Task<bool> HealthCheck(string serverUrl)
        {
            var result = await _httpClient.GetAsync($"{serverUrl}/health");
            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;

        }
    }
}
