#pragma checksum "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e24ec27f0889c915ab86756020c2dcfe82eb7ea0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LendBook_Index), @"mvc.1.0.view", @"/Views/LendBook/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Git\vivlio-s2\Vivlio\Views\_ViewImports.cshtml"
using Vivlio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Git\vivlio-s2\Vivlio\Views\_ViewImports.cshtml"
using Vivlio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e24ec27f0889c915ab86756020c2dcfe82eb7ea0", @"/Views/LendBook/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dd4135c5183478f6abaccee40e12e9a80602151", @"/Views/_ViewImports.cshtml")]
    public class Views_LendBook_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
  
    ViewData["Title"] = "Uitlenen";
    var Users = Model as System.Data.DataTable;
    var Books = ViewData["bookTable"] as System.Data.DataTable;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <style>\r\n        .form-control {\r\n            width: 50%;\r\n        }\r\n    </style>\r\n\r\n<h1>Uitlenen</h1>\r\n\r\n<div id=\"partial\"></div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e24ec27f0889c915ab86756020c2dcfe82eb7ea04559", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 19 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
      ViewData["Name"] = "User";

#line default
#line hidden
#nullable disable
                WriteLiteral("    <input type=\"number\"");
                BeginWriteAttribute("id", " id=\"", 403, "\"", 432, 2);
                WriteAttributeValue("", 408, "search_", 408, 7, true);
#nullable restore
#line 20 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
WriteAttributeValue("", 415, ViewData["Name"], 415, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"GebruikersID\" name=\"UserID\" class=\"form-control\" />\r\n");
#nullable restore
#line 21 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
      Html.RenderPartial("../Partial/Searchbar", Users); 

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <br />\r\n\r\n");
#nullable restore
#line 25 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
      ViewData["Name"] = "Book";

#line default
#line hidden
#nullable disable
                WriteLiteral("    <input type=\"number\"");
                BeginWriteAttribute("id", " id=\"", 635, "\"", 664, 2);
                WriteAttributeValue("", 640, "search_", 640, 7, true);
#nullable restore
#line 26 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
WriteAttributeValue("", 647, ViewData["Name"], 647, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"BoekID\" name=\"BookID\" class=\"form-control\"/>\r\n");
#nullable restore
#line 27 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
      Html.RenderPartial("../Partial/Searchbar", Books); 

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <br />\r\n    <button type=\"button\" id=\"submit\" class=\"btn btn-primary btn-rounded SubmitButton\" style=\"border-radius:2rem;\" >Uitlenen</button>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<script>\r\n    var url = \'");
#nullable restore
#line 37 "D:\Git\vivlio-s2\Vivlio\Views\LendBook\Index.cshtml"
          Write(Url.Action("LendBookResult", "Book", new { BookID = "BookID", UserID = "UserID" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    $('#submit').on('click',function(e){
        e.preventDefault();
        $.ajax({
            type: ""POST"",
            url: url,
            data:$('form').serialize(),
        }).done(function (r) {
            $('#partial').html(r);
            var frm = document.getElementById(""form"");
            frm.reset();

        }).fail(function (e) {
            console.log(e.responseText);
        });
    });
</script>
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
