// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BookStore_UI.Pages.Users
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
#line 2 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Users\Register.razor"
using BookStore_UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Users\Register.razor"
using BookStore_UI.Contracts;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "E:\WORK\aspdotnet core\Book-Store-Api-Dev-on-.net-core-3.1-\BookStore-UI\Pages\Users\Register.razor"
       

    private RegistrationModel Model = new RegistrationModel();
    bool isFailed = false;

    private async Task HandleRegistration()
    {
        var response = await _authRepo.Register(Model);


        if (response)
        {
            _navMan.NavigateTo("/");
        }
        else
        {
            isFailed = true;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navMan { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationRepository _authRepo { get; set; }
    }
}
#pragma warning restore 1591
