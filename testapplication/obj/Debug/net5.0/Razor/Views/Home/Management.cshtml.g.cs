#pragma checksum "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d205dfb84478b21419273542ceaf7f0a9346dc11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Management), @"mvc.1.0.view", @"/Views/Home/Management.cshtml")]
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
#line 1 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\_ViewImports.cshtml"
using testapplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\_ViewImports.cshtml"
using testapplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d205dfb84478b21419273542ceaf7f0a9346dc11", @"/Views/Home/Management.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c1b873267e69b62aec4212a7bdfccd5ac7bd5be", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Management : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
  
    ViewData["Title"] = "???????? ????????????";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
 if (!string.IsNullOrWhiteSpace(ViewBag.deletefromfamily))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\" role=\"alert\">\r\n        <p>");
#nullable restore
#line 12 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
      Write(ViewBag.Duplicates);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 14 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d205dfb84478b21419273542ceaf7f0a9346dc115713", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"card mb-2\">\r\n        <h5 class=\"card-header\">?????????????? ??????????</h5>\r\n        <div class=\"card-body text-center row\">\r\n\r\n");
#nullable restore
#line 23 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
             if (ViewBag.AdminUser != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group col-md-4 \">\r\n                    <label class=\"control-label font-weight-bold\">?????? ?? ?????? ????????????????:</label>\r\n                    <label id=\"info_label\" class=\"control-label\">");
#nullable restore
#line 27 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
                                                            Write(ViewBag.AdminUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 27 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
                                                                                         Write(ViewBag.AdminUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                </div>\r\n                <div class=\"form-group col-md-3 \">\r\n                    <label class=\"control-label font-weight-bold\">??????????:</label>\r\n                    <label class=\"control-label\">");
#nullable restore
#line 31 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
                                            Write(ViewBag.AdminUser.NationalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                </div>\r\n");
            WriteLiteral("                <div class=\"form-group col-lg-2\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1125, "\"", 1198, 1);
#nullable restore
#line 35 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
WriteAttributeValue("", 1132, Url.Action("Register", "Home", new {page_name = "managmentedit"}), 1132, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">\r\n                        ????????????\r\n                    </a>\r\n");
            WriteLiteral("                </div>\r\n                <div class=\"form-group col-lg-2 \">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d205dfb84478b21419273542ceaf7f0a9346dc119405", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d205dfb84478b21419273542ceaf7f0a9346dc119687", async() => {
                    WriteLiteral("\r\n                            <span class=\"glyphicon glyphicon-lock\"></span>?????????? ???????? ????????\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 50 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Management.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>

    </div>


    <div class=""row"">
        <div class=""col-3 pl-4"">
            <ul class=""nav flex-column p-0"" id=""titleId"">
                <li class=""nav-item"">
                    <button value=""rel"" id=""FamilyType"" class=""TitleType btn btn-block btn-info m-1 "">???????? ????????????????</button>
                </li>
                <li class=""nav-item"">
                    <button id=""DegreeEducation"" class=""TitleType btn btn-block btn-info m-1 "">???????? ????????????</button>
                </li>
                <li class=""nav-item"">
                    <button id=""Religion"" class=""TitleType btn btn-block btn-info m-1 "">??????</button>
                </li>
                <li class=""nav-item"">
                    <button id=""MilitaryStatus"" class=""TitleType btn btn-block btn-info m-1"">?????????? ????????</button>
                </li>
                <li class=""nav-item"">
                    <button id=""Province"" class=""TitleType btn btn-block btn-info m-1"">??????????</button>
                </li>
  ");
            WriteLiteral("              <li class=\"nav-item\">\r\n                    <button id=\"User\" class=\"TitleType btn btn-block btn-info m-1\">??????????????</button>\r\n                </li>\r\n");
            WriteLiteral("                \r\n\r\n\r\n            </ul>\r\n        </div>\r\n        <div class=\"col-9\" id=\"div1\">\r\n\r\n\r\n");
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral(@"
<!--<script>
    //var _url =

    $.ajax({
        url: ""/Home/saveRows"",
        type: ""GET"",
        dataType: ""json"",
        
        //success: function (res) {
        //    alert(res);
        //},
        //error: function (res) {
        //    alert(""ackna"");
        //}

    });-->

");
            WriteLiteral("<!--</script>-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
