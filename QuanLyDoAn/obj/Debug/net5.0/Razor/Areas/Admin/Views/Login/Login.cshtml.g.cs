#pragma checksum "C:\Users\TIEN\source\repos\QuanLyDoAn\QuanLyDoAn\Areas\Admin\Views\Login\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3ee55ad9f5cd2ce6ef1ac2495edc0b9ae45e391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Login_Login), @"mvc.1.0.view", @"/Areas/Admin/Views/Login/Login.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3ee55ad9f5cd2ce6ef1ac2495edc0b9ae45e391", @"/Areas/Admin/Views/Login/Login.cshtml")]
    public class Areas_Admin_Views_Login_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuanLyDoAn.Models.UserAdmin>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<tbody>\r\n");
#nullable restore
#line 4 "C:\Users\TIEN\source\repos\QuanLyDoAn\QuanLyDoAn\Areas\Admin\Views\Login\Login.cshtml"
     using (Html.BeginForm("Login", "Login", FormMethod.Post))
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n\r\n            Username : ");
#nullable restore
#line 9 "C:\Users\TIEN\source\repos\QuanLyDoAn\QuanLyDoAn\Areas\Admin\Views\Login\Login.cshtml"
                  Write(Html.TextBoxFor(m => m.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div> Password : ");
#nullable restore
#line 12 "C:\Users\TIEN\source\repos\QuanLyDoAn\QuanLyDoAn\Areas\Admin\Views\Login\Login.cshtml"
                    Write(Html.TextBoxFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <input type=\"submit\" value=\" Login\" />\r\n");
#nullable restore
#line 14 "C:\Users\TIEN\source\repos\QuanLyDoAn\QuanLyDoAn\Areas\Admin\Views\Login\Login.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</tbody>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuanLyDoAn.Models.UserAdmin> Html { get; private set; }
    }
}
#pragma warning restore 1591
