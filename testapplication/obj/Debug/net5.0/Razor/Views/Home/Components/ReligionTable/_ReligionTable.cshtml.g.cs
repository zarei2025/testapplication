#pragma checksum "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "207e22587b599cd1bfb89fbc888d53f02e49cdba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Components_ReligionTable__ReligionTable), @"mvc.1.0.view", @"/Views/Home/Components/ReligionTable/_ReligionTable.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"207e22587b599cd1bfb89fbc888d53f02e49cdba", @"/Views/Home/Components/ReligionTable/_ReligionTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c1b873267e69b62aec4212a7bdfccd5ac7bd5be", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Components_ReligionTable__ReligionTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<testapplication.Models.Tables_Model.ReligionItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form row mx-lg-auto "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div id=\"table\" class=\"table-editable\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "207e22587b599cd1bfb89fbc888d53f02e49cdba3905", async() => {
                WriteLiteral("\r\n        <div class=\"form-group col-5 mx-1\">\r\n            <a");
                BeginWriteAttribute("href", " href=\"", 214, "\"", 254, 1);
#nullable restore
#line 6 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
WriteAttributeValue("", 221, Url.Action("CreateItem", "Home"), 221, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-dark\">\r\n                افزودن یک سطر جدید\r\n            </a>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <table class=""table table-bordered table-sm table-striped text-center"" id=""myTable"">
        <thead>
        <tr>
            <th>
                #
            </th>
            <th>
                دین
            </th>
            <th>
                عملیات
            </th>
        </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 27 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n\r\n                    ");
#nullable restore
#line 32 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
                Write(Model.IndexOf(item) + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </td>\r\n                <td onblur=\"blurRow(this)\" onfocus=\"focusRow(this)\">\r\n\r\n                    ");
#nullable restore
#line 37 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </td>\r\n\r\n                <td>\r\n\r\n");
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1266, "\"", 1324, 1);
#nullable restore
#line 47 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
WriteAttributeValue("", 1273, Url.Action("EditItem", "Home", new {id = item.Id}), 1273, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">\r\n                        ویرایش\r\n                    </a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1432, "\"", 1492, 1);
#nullable restore
#line 50 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
WriteAttributeValue("", 1439, Url.Action("DeleteItem", "Home", new {id = item.Id}), 1439, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">\r\n                        حذف <span class=\"badge bg-white text-dark\">");
#nullable restore
#line 51 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
                                                              Write(item.UseCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                    </a>\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Parto\Source\Repos\zarei2025\testapplication\testapplication\Views\Home\Components\ReligionTable\_ReligionTable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n\r\n    </table>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<testapplication.Models.Tables_Model.ReligionItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
