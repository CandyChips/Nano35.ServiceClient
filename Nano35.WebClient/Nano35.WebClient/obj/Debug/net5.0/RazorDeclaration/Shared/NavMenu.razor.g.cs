// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Nano35.WebClient.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Nano35.WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Nano35.WebClient.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
