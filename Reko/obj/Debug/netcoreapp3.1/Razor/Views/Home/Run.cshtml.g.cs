#pragma checksum "C:\Users\artemya\Desktop\New folder (2)\Reko\Reko\Views\Home\Run.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27489d20f3e900a05a96b70f71cfb066db256c88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Run), @"mvc.1.0.view", @"/Views/Home/Run.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27489d20f3e900a05a96b70f71cfb066db256c88", @"/Views/Home/Run.cshtml")]
    public class Views_Home_Run : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1 class=\"mt-5\">Sticky footer with fixed navbar</h1>\r\n<p class=\"lead\">\r\n    Info: ");
#nullable restore
#line 4 "C:\Users\artemya\Desktop\New folder (2)\Reko\Reko\Views\Home\Run.cshtml"
     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<p>Back to <a");
            BeginWriteAttribute("href", " href=\"", 125, "\"", 152, 1);
#nullable restore
#line 6 "C:\Users\artemya\Desktop\New folder (2)\Reko\Reko\Views\Home\Run.cshtml"
WriteAttributeValue("", 132, Url.Action("Index"), 132, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Home page</a> </p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
