using Microsoft.AspNetCore.Components;
using Nano35.HttpContext.identity;
using Nano35.WebClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nano35.WebClient.Pages
{
    public partial class Login
    {
        // ToDo add healthcheck to identity server and add firewall on server not found
        [Inject]
        private IRequestManager _requestManager { get; set; }

        [Inject]
        private IAuthService _authService { get; set; }

        // ToDo add [Required] attribute to model on httpcontext project
        private GenerateUserTokenBody model = new GenerateUserTokenBody();
        private bool loading;
        private string error;

        protected override void OnInitialized()
        {
            // ToDo implement healthcheck here!!!
        }

        // ToDo responce of request shown on second click to button
        private async void HandleValidSubmit()
        {
            try
            {
                await _authService.Login(model);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

    }
}
