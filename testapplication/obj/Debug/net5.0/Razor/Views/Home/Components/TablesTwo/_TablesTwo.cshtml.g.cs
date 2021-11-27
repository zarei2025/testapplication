#pragma checksum "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed0d99f3add3e1b76b9f6210c2978435b1d4d8db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Components_TablesTwo__TablesTwo), @"mvc.1.0.view", @"/Views/Home/Components/TablesTwo/_TablesTwo.cshtml")]
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
#line 1 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\_ViewImports.cshtml"
using testapplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\_ViewImports.cshtml"
using testapplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed0d99f3add3e1b76b9f6210c2978435b1d4d8db", @"/Views/Home/Components/TablesTwo/_TablesTwo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c1b873267e69b62aec4212a7bdfccd5ac7bd5be", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Components_TablesTwo__TablesTwo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""table"" class=""table-editable"">

    <table class=""table table-bordered table-sm table-striped text-center"" id=""myTable"">
        <thead>
        <tr>
            <th>
                ردیف
            </th>
            <th>
                عنوان
            </th>
            <th>
                عملیات
            </th>
        </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 21 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
                Write(Model.IndexOf(item) + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n\r\n                    ");
#nullable restore
#line 27 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
               Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                </td>

                <td>

                    <button type=""button"" class=""btn btn-danger btn-rounded btn-sm my-0"" onclick=""deleteRow(this)"">
                        حذف
                    </button>

                </td>

            </tr>
");
#nullable restore
#line 41 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </tbody>

    </table>
    <span class=""table-add float-right mb-3 mr-2"">
        <a href=""#!"" class=""btn btn-dark "" onclick=""addRow()"">
            <i class=""fas fa-plus"" aria-hidden=""true""> &nbsp; افزودن یک سطر جدید </i>
        </a>
    </span>
</div>
");
#nullable restore
#line 52 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
 if (!string.IsNullOrWhiteSpace(ViewBag.Duplicates))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert-danger p-3 m-3\">\r\n        <p>");
#nullable restore
#line 55 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
      Write(ViewBag.Duplicates);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 57 "C:\Users\Muhammad\Source\Repos\testapplication\testapplication\Views\Home\Components\TablesTwo\_TablesTwo.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function addRow() {

        var table = document.getElementById(""myTable"");
        var row = table.insertRow();
        var cell0 = row.insertCell(0);
        var cell1 = row.insertCell(1);
        var cell2 = row.insertCell(2);
        var i = row.rowIndex;
        cell0.innerHTML = i;
        cell1.contentEditable = 'true';
    }
</script>

<script>
    function deleteRow(r) {

        var j = r.parentNode.parentNode.rowIndex;
        var table = document.getElementById(""myTable"");
        table.deleteRow(j);


        for (var i = j; i < table.rows.length; i++) {
            var x = table.rows[i].cells;
            x[0].innerHTML = i;

        }
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
