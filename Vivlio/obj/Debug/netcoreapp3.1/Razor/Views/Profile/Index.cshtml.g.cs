#pragma checksum "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90b91cfb35ef2526151999bc99935ba850a30ecd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90b91cfb35ef2526151999bc99935ba850a30ecd", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dd4135c5183478f6abaccee40e12e9a80602151", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
  
    ViewData["Title"] = "Profiel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<style>\r\n    .Alphabet {\r\n        overflow: scroll;\r\n        overflow-x: hidden;\r\n        overflow-y: auto;\r\n    }\r\n\r\n    .form-control {\r\n        width: 50%;\r\n    }\r\n</style>\r\n\r\n<h1>Profiel</h1>\r\n\r\n<span style=\"color: red; display:block;\">   ");
#nullable restore
#line 22 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                       Write(Html.ValidationMessage("Alert"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n<span style=\"color: green; display:block;\"> ");
#nullable restore
#line 23 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                       Write(Html.ValidationMessage("Succes"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n<strong> Roepnaam: </strong> ");
#nullable restore
#line 25 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<strong> Gebruikersnaam: </strong> ");
#nullable restore
#line 27 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                              Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<strong> Email: </strong> ");
#nullable restore
#line 29 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                     Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 32 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
  
    if (!String.IsNullOrEmpty(Model.Phonenumber))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <strong> Telefoonnummer: </strong> ");
#nullable restore
#line 35 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                      Write(Model.Phonenumber.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n");
#nullable restore
#line 37 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<strong> Functie: </strong> ");
#nullable restore
#line 39 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                       Write(Model.UserFunction);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<button type=\"button\" class=\"btn btn-primary btn-rounded\" style=\"border-radius:2rem; margin-top:10px;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 923, "\"", 1017, 2);
#nullable restore
#line 41 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
WriteAttributeValue("", 933, "window.location.href='" + @Url.Action("ChangeAccountInfoView", "Account") + "'", 933, 83, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1016, ";", 1016, 1, true);
            EndWriteAttribute();
            WriteLiteral(" >Wijzig gegevens </button>\r\n<br />\r\n\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 48 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
  
    Vivlio.Containers.UserContainer userContainer = new Vivlio.Containers.UserContainer(new Vivlio.DAL_s.UserDAL());

    var table = userContainer.GetUserBooks(Model.Username);


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Geleende boeken:</h3>\r\n\r\n<div id=\"partial\"></div>\r\n\r\n");
#nullable restore
#line 59 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
  string name = "Books";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 62 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
     if (table.Rows.Count != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"text\"");
            BeginWriteAttribute("id", " id=\"", 1413, "\"", 1430, 2);
            WriteAttributeValue("", 1418, "search_", 1418, 7, true);
#nullable restore
#line 64 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
WriteAttributeValue("", 1425, name, 1425, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Boek ID\" name=\"Zoeken..\" class=\"form-control\" />\r\n");
            WriteLiteral("        <div class=\"table-wrapper-scroll-y my-custom-scrollbar\">\r\n            <table class=\"table table-bordered table-striped mb-0 tablewidth\"");
            BeginWriteAttribute("id", " id=\"", 1640, "\"", 1650, 1);
#nullable restore
#line 67 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
WriteAttributeValue("", 1645, name, 1645, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <thead>\r\n                    <tr class=\"topRow\">\r\n                        <th scope=\"col\">");
#nullable restore
#line 70 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                   Write(table.Columns[0].Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\">");
#nullable restore
#line 71 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                   Write(table.Columns[1].Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\">");
#nullable restore
#line 72 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                   Write(table.Columns[2].Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\">");
#nullable restore
#line 73 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                   Write(table.Columns[3].Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\"> Verlengen</th>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 77 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                     foreach (DataRow row in table.Rows)
                    {
                        DateTime date = (DateTime)row[3];

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr scope=\"row\">\r\n                            <td class=\"ID\">");
#nullable restore
#line 81 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                                      Write(row[0].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 82 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                           Write(row[1].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 83 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                           Write(row[2].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 84 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                           Write(date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 86 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                             if ((DateTime)row[3] > DateTime.Now)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>  <button type=\"button\" class=\"use-address\"> Boek verlengen</button> </td>\r\n");
#nullable restore
#line 89 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"red\"> Dit boek is te laat! </td>\r\n");
#nullable restore
#line 93 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tr>\r\n");
#nullable restore
#line 96 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n");
#nullable restore
#line 100 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <span>Je hebt geen boeken uitgeleend!</span>\r\n");
#nullable restore
#line 105 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<script src=\"https://code.jquery.com/jquery-1.8.3.min.js\"></script>\r\n\r\n<script type=\"text/javascript\">\r\n$(\"#search_");
#nullable restore
#line 112 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
      Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").on(\"keyup\", function () {\r\n    var value = $(this).val();\r\n    $(\"#");
#nullable restore
#line 114 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
   Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" tr"").each(function (index) {
        if (index !== 0) {
            $row = $(this);
            var id = $row.find(""td"").eq(0).text();
            var idTwo = $row.find(""td"").eq(1).text();

            if (id.indexOf(value) !== 0 && idTwo.indexOf(value) !== 0) {
                $row.hide();
            }
            else {
                $row.show();
            }
        }
    });
});

$("".use-address"").click(function() {
    var $row = $(this).closest(""tr"");    // Find the row
    var $text = $row.find("".ID"").text(); // Find the text

    var url = '");
#nullable restore
#line 134 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
          Write(Url.Action("ProlongBookResult", "Book"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n\r\n    $.ajax({\r\n        type: \"POST\",\r\n        url: url,\r\n        data: { \'userID\':");
#nullable restore
#line 139 "D:\Git\vivlio-s2\Vivlio\Views\Profile\Index.cshtml"
                    Write(Model.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \'bookID\': $text },\r\n    }).done(function (r) {\r\n        $(\'#partial\').html(r);\r\n\r\n    }).fail(function (e) {\r\n        console.log(e.responseText);\r\n    });\r\n});\r\n</script>\r\n\r\n");
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
