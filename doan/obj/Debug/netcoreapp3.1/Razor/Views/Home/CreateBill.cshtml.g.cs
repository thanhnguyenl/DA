#pragma checksum "C:\doan\doan\Views\Home\CreateBill.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a0e12b54f73453417217893841733a23492b9d6aeee76441b4f8bb3abdafd930"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateBill), @"mvc.1.0.view", @"/Views/Home/CreateBill.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\doan\doan\Views\_ViewImports.cshtml"
using doan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\doan\doan\Views\_ViewImports.cshtml"
using doan.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a0e12b54f73453417217893841733a23492b9d6aeee76441b4f8bb3abdafd930", @"/Views/Home/CreateBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cce363cd64b7577821889ba2326c8599bb027344d8fef3990015bd278c1ecc14", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_CreateBill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<doan.Models.Hoadon>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\doan\doan\Views\Home\CreateBill.cshtml"
  
    ViewData["Title"] = "Đặt hàng thành công";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>Đặt hàng thành công</h3>\r\n<p>Đơn hàng mã số ");
#nullable restore
#line 6 "C:\doan\doan\Views\Home\CreateBill.cshtml"
             Write(Model.MaHd);

#line default
#line hidden
#nullable disable
            WriteLiteral(" trị giá ");
#nullable restore
#line 6 "C:\doan\doan\Views\Home\CreateBill.cshtml"
                                  Write(((int)Model.TongTien).ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("đ đã được hệ thống ghi nhận. Chúng tôi sẽ sớm liên hệ bạn để xác nhận...</p>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<doan.Models.Hoadon> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
