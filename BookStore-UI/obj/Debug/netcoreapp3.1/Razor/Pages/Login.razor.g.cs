#pragma checksum "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3d9ee54a72a5c4099ef6be280406c95bc3f644c"
// <auto-generated/>
#pragma warning disable 1591
namespace BookStore_UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using BookStore_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\_Imports.razor"
using BookStore_UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
using BookStore_UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
using BookStore_UI.Contracts;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "card");
            __builder.AddMarkupContent(2, "<h3>Class=\"card-title\">Login</h3>");
#nullable restore
#line 12 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
     if (!response)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(3, "<div class=\"alert alert-danger\"><p>Something went wrong with the Login attempt </p></div>");
#nullable restore
#line 17 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "card-body");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(6);
            __builder.AddAttribute(7, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 19 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
                         Model

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 19 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
                                                 HandleLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(10);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(11, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(12);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(13, "\r\n            ");
                __builder2.OpenElement(14, "div");
                __builder2.AddAttribute(15, "class", "form-group");
                __builder2.AddMarkupContent(16, "<label for=\"email\">Email Address</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(17);
                __builder2.AddAttribute(18, "Id", "email");
                __builder2.AddAttribute(19, "class", "form-control");
                __builder2.AddAttribute(20, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
                                                                        Model.EmailAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Model.EmailAddress = __value, Model.EmailAddress))));
                __builder2.AddAttribute(22, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Model.EmailAddress));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(23, "\r\n                ");
                __Blazor.BookStore_UI.Pages.Login.TypeInference.CreateValidationMessage_0(__builder2, 24, 25, 
#nullable restore
#line 25 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
                                          ()=> Model.EmailAddress

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n\r\n            ");
                __builder2.OpenElement(27, "div");
                __builder2.AddAttribute(28, "class", "form-group");
                __builder2.AddMarkupContent(29, "<label for=\"password\">Password</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(30);
                __builder2.AddAttribute(31, "Id", "password");
                __builder2.AddAttribute(32, "type", "password");
                __builder2.AddAttribute(33, "class", "form-control");
                __builder2.AddAttribute(34, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
                                                                                           Model.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Model.Password = __value, Model.Password))));
                __builder2.AddAttribute(36, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Model.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(37, "\r\n                ");
                __Blazor.BookStore_UI.Pages.Login.TypeInference.CreateValidationMessage_1(__builder2, 38, 39, 
#nullable restore
#line 32 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
                                          ()=> Model.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n\r\n            \r\n            ");
                __builder2.AddMarkupContent(41, "<button type=\"submit\" class=\"btn btn-primary btn-block\">Login</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Login.razor"
       

    private LoginModel Model = new LoginModel();

    private bool response = true;
    private async Task HandleLogin()
    {
        var response = await _authRepo.Login(Model);


        if (response)
        {
            _navManager.NavigateTo("/");
        }

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationRepository _authRepo { get; set; }
    }
}
namespace __Blazor.BookStore_UI.Pages.Login
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
    }
}
#pragma warning restore 1591
