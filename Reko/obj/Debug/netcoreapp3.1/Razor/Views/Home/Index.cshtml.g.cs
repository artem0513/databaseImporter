#pragma checksum "C:\Users\artemya\Desktop\WORKED\New folder\Reko\Reko\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a73f11d2d33be79d178c70cc266f90014b9a322"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a73f11d2d33be79d178c70cc266f90014b9a322", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        Featured\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">Dates</h5>\r\n        <form");
            BeginWriteAttribute("action", " action=\"", 166, "\"", 193, 1);
#nullable restore
#line 7 "C:\Users\artemya\Desktop\WORKED\New folder\Reko\Reko\Views\Home\Index.cshtml"
WriteAttributeValue("", 175, Url.Action("Run"), 175, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" method=""post"">
            <div class=""table"">
                <div class=""row"">
                    <div class=""col-6"">
                        <input type=""date"" name=""from"" placeholder=""From"" />
                    </div>
                    <div class=""col-6"">
                        <input type=""date"" name=""to"" placeholder=""To"" />
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-12"">
                        <input type=""submit"" class=""btn btn-primary"" value=""Run"" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591