#pragma checksum "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0d4f68817537b08bcdfeef0823d9b73acba6bfd"
// <auto-generated/>
#pragma warning disable 1591
namespace Nano35.WebClient.Pages
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
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Nano35.WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\_Imports.razor"
using Nano35.WebClient.Shared;

#line default
#line hidden
#nullable disable
    public partial class ModalNewInstance : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 1 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
 if (this.Display)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal-background");
            __builder.AddAttribute(2, "b-kdspcsomfv");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "modal-content card");
            __builder.AddAttribute(5, "b-kdspcsomfv");
            __builder.AddMarkupContent(6, "<h4 class=\"card-header\" b-kdspcsomfv>Новая организация</h4>\r\n            ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "card-body");
            __builder.AddAttribute(9, "b-kdspcsomfv");
#nullable restore
#line 7 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
             if (!_loading)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(10);
            __builder.AddAttribute(11, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 9 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                  model

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 9 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                        Create

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(14);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n                    ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "class", "form-group");
                __builder2.AddAttribute(18, "b-kdspcsomfv");
                __builder2.AddMarkupContent(19, "<label b-kdspcsomfv>Название сервиса</label>\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(20);
                __builder2.AddAttribute(21, "class", "form-control");
                __builder2.AddAttribute(22, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                model.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Name = __value, model.Name))));
                __builder2.AddAttribute(24, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(25, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_0(__builder2, 26, 27, 
#nullable restore
#line 14 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n                    ");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "form-group");
                __builder2.AddAttribute(31, "b-kdspcsomfv");
                __builder2.AddMarkupContent(32, "<label b-kdspcsomfv>Эл почта</label>\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(33);
                __builder2.AddAttribute(34, "class", "form-control");
                __builder2.AddAttribute(35, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 18 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                model.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Email = __value, model.Email))));
                __builder2.AddAttribute(37, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(38, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_1(__builder2, 39, 40, 
#nullable restore
#line 19 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n                    ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "form-group");
                __builder2.AddAttribute(44, "b-kdspcsomfv");
                __builder2.AddMarkupContent(45, "<label b-kdspcsomfv>Номер телефона</label>\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(46);
                __builder2.AddAttribute(47, "class", "form-control");
                __builder2.AddAttribute(48, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                model.Phone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(49, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Phone = __value, model.Phone))));
                __builder2.AddAttribute(50, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Phone));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(51, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_2(__builder2, 52, 53, 
#nullable restore
#line 24 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.Phone

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(54, "\r\n                    ");
                __builder2.OpenElement(55, "div");
                __builder2.AddAttribute(56, "class", "form-group");
                __builder2.AddAttribute(57, "b-kdspcsomfv");
                __builder2.AddMarkupContent(58, "<label b-kdspcsomfv>Название организации</label>\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(59);
                __builder2.AddAttribute(60, "class", "form-control");
                __builder2.AddAttribute(61, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                model.RealName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(62, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.RealName = __value, model.RealName))));
                __builder2.AddAttribute(63, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.RealName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(64, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_3(__builder2, 65, 66, 
#nullable restore
#line 29 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.RealName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(67, "\r\n                    ");
                __builder2.OpenElement(68, "div");
                __builder2.AddAttribute(69, "class", "form-group");
                __builder2.AddAttribute(70, "b-kdspcsomfv");
                __builder2.AddMarkupContent(71, "<label b-kdspcsomfv>Описание</label>\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(72);
                __builder2.AddAttribute(73, "class", "form-control");
                __builder2.AddAttribute(74, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                model.Info

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(75, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Info = __value, model.Info))));
                __builder2.AddAttribute(76, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Info));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(77, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_4(__builder2, 78, 79, 
#nullable restore
#line 34 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.Info

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(80, "\r\n                    ");
                __builder2.OpenElement(81, "div");
                __builder2.AddAttribute(82, "class", "form-group");
                __builder2.AddAttribute(83, "b-kdspcsomfv");
                __builder2.AddMarkupContent(84, "<label b-kdspcsomfv>Регион</label>\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateInputSelect_5(__builder2, 85, 86, "custom-select", 87, 
#nullable restore
#line 38 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  model.RegionId

#line default
#line hidden
#nullable disable
                , 88, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.RegionId = __value, model.RegionId)), 89, () => model.RegionId, 90, (__builder3) => {
                    __builder3.AddMarkupContent(91, "<option selected disabled b-kdspcsomfv>Choose...</option>");
#nullable restore
#line 40 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                             foreach (var item in _regions)
                            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(92, "option");
                    __builder3.AddAttribute(93, "value", 
#nullable restore
#line 42 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                item.Id

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddAttribute(94, "b-kdspcsomfv");
                    __builder3.AddContent(95, 
#nullable restore
#line 42 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                          item.Name

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
#nullable restore
#line 43 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                            }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.AddMarkupContent(96, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_6(__builder2, 97, 98, 
#nullable restore
#line 45 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.RegionId

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(99, "\r\n                    ");
                __builder2.OpenElement(100, "div");
                __builder2.AddAttribute(101, "class", "form-group");
                __builder2.AddAttribute(102, "b-kdspcsomfv");
                __builder2.AddMarkupContent(103, "<label b-kdspcsomfv>Тип</label>\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateInputSelect_7(__builder2, 104, 105, "custom-select", 106, 
#nullable restore
#line 49 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  model.TypeId

#line default
#line hidden
#nullable disable
                , 107, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.TypeId = __value, model.TypeId)), 108, () => model.TypeId, 109, (__builder3) => {
                    __builder3.AddMarkupContent(110, "<option selected disabled b-kdspcsomfv>Choose...</option>");
#nullable restore
#line 51 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                             foreach (var item in _types)
                            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(111, "option");
                    __builder3.AddAttribute(112, "value", 
#nullable restore
#line 53 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                item.Id

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddAttribute(113, "b-kdspcsomfv");
                    __builder3.AddContent(114, 
#nullable restore
#line 53 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                          item.Name

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
#nullable restore
#line 54 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                            }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.AddMarkupContent(115, "\r\n                        ");
                __Blazor.Nano35.WebClient.Pages.ModalNewInstance.TypeInference.CreateValidationMessage_8(__builder2, 116, 117, 
#nullable restore
#line 56 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                  () => model.TypeId

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 58 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                     if (!string.IsNullOrEmpty(_error))
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(118, "div");
                __builder2.AddAttribute(119, "class", "alert alert-danger mt-3 mb-0");
                __builder2.AddAttribute(120, "b-kdspcsomfv");
                __builder2.AddContent(121, 
#nullable restore
#line 60 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                                                   _error

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 61 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(122, "div");
                __builder2.AddAttribute(123, "b-kdspcsomfv");
                __builder2.AddMarkupContent(124, "<button class=\"btn btn-primary\" b-kdspcsomfv>\r\n                            Создать\r\n                        </button>\r\n                        ");
                __builder2.OpenElement(125, "button");
                __builder2.AddAttribute(126, "class", "btn btn-secondary");
                __builder2.AddAttribute(127, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 67 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
                                          Hide

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(128, "b-kdspcsomfv");
                __builder2.AddMarkupContent(129, "Закрыть\r\n                        ");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 71 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 75 "C:\Users\user\RiderProjects\Nano35.ServiceClient\Nano35.WebClient\Nano35.WebClient\Pages\ModalNewInstance.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.Nano35.WebClient.Pages.ModalNewInstance
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3, int __seq4, global::Microsoft.AspNetCore.Components.RenderFragment __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.AddAttribute(__seq4, "ChildContent", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_7<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3, int __seq4, global::Microsoft.AspNetCore.Components.RenderFragment __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.AddAttribute(__seq4, "ChildContent", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_8<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
