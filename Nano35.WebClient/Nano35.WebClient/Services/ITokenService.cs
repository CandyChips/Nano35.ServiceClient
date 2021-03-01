using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Nano35.WebClient.Services
{
    public interface ITokenService
    {
        void SaveToken(string token);
        void RemoveToken();
        AuthenticationHeaderValue GetIdentityHeader();
        bool IsTokenValid();
    }

    public class TokenService : 
        ITokenService
    {
        private string _token;

        public AuthenticationHeaderValue GetIdentityHeader()
        {
            return new AuthenticationHeaderValue("Bearer", _token);
        }

        public bool IsTokenValid()
        {
            return _token != null;
        }

        public void RemoveToken()
        {
            _token = null;
        }

        public void SaveToken(string token)
        {
            _token = token;
        }
    }
}
