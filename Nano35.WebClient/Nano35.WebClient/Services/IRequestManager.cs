using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nano35.WebClient.Services
{
    public interface IRequestManager
    {
        string LocalIdentityServer { get; }
        string IdentityServer { get; }
        string InstanceServer { get; }
        string StorageServer { get; }
        string RepairOrdersServer { get; }
        string FileServer { get; }
        bool HealthCheck(string serverUrl);
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

        public string LocalIdentityServer => "http://localhost:5001/Identity";
        public string LocalInstanceServer => "http://localhost:5002/Instance";

        public string LocalStorageServer => "http://localhost:5003/Storage";

        public string LocalRepairOrdersServer => "http://localhost:5004";

        public string LocalFileServer => "http://localhost:5005";

        public bool HealthCheck(string serverUrl)
        {
            var result = _httpClient.GetAsync($"{serverUrl}/health").Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
