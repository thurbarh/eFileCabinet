#pragma checksum "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\File\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f4fced8de4d5870ef8edc8beab2238eadd1d922"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_File_Index), @"mvc.1.0.view", @"/Views/File/Index.cshtml")]
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
#line 1 "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\_ViewImports.cshtml"
using DocumentServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\_ViewImports.cshtml"
using DocumentServer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f4fced8de4d5870ef8edc8beab2238eadd1d922", @"/Views/File/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cf3ace8f9a392b1fa35eb70f719eeccd9a3dd4d", @"/Views/_ViewImports.cshtml")]
    public class Views_File_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DocumentServer.Models.ViewModels.UploadViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("uploadbtn btn btn-dark "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "File", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Upload", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f4fced8de4d5870ef8edc8beab2238eadd1d9225461", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\File\Index.cshtml"
     if (ViewBag.Message != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"alert alert-success alert-dismissible\" style=\"margin-top:20px\">\r\n            ");
#nullable restore
#line 6 "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\File\Index.cshtml"
       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 8 "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\File\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f4fced8de4d5870ef8edc8beab2238eadd1d9226500", async() => {
                    WriteLiteral(@"

        <div class=""custom-file-container"" data-upload-id=""mySecondImage"">
            <h4>Upload File</h4>

            
            <label class=""custom-file-container__custom-file"">
                <input type=""file"" name=""files"" class=""custom-file-container__custom-file__custom-file-input"" multiple required>

            </label>


            <input type=""text"" class=""custom-description-container-control"" autocomplete=""off"" placeholder=""Enter File Description"" name=""description"" />

            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f4fced8de4d5870ef8edc8beab2238eadd1d9227306", async() => {
                        WriteLiteral("Upload");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n\r\n\r\n            <div hidden class=\"custom-file-container__image-preview\"></div>\r\n        </div>\r\n\r\n\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"


    <div class=""  layout-spacing"">
        <div class=""widget-content widget-content-area br-6"" style=""font-size: large;"">

            <div class=""table-responsive "">

                <table id=""fileList"" class=""table"" style=""width:100%"">
                    <thead>
                        <tr>
                           
                            <th>Name</th>
                            <th>Description</th>
                            <th>Size(bytes)</th>
                            <th>Date Added</th>
                            <th>Download</th>
                            <th>Delete</th>

                        </tr>
                    </thead>
                    <tbody>

");
                WriteLiteral("                    </tbody>\r\n\r\n                </table>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n");
                DefineSection("scripts", async() => {
                    WriteLiteral("\r\n        <!-- DataTable SCRIPTS -->\r\n        <script>\r\n\r\n            $(document).ready(function () {\r\n                $(\'#fileList\').DataTable({\r\n           \r\n                    \"ajax\": {\r\n                        \"url\":\'");
#nullable restore
#line 89 "C:\Users\adegs\source\repos\thurbarh\eFileCabinet\Views\File\Index.cshtml"
                          Write(Url.Action("GetAllFiles", "File"));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"',
                        ""type"": ""GET"",
                        ""data"": ""json""
                            },




                    ""columns"": [
                      
                        { ""data"": ""name""},
                        {
                            ""data"": ""description""

                        },

                        {
                            ""data"": ""size_in_Bytes""

                        },
                        {
                            ""data"": ""dateAdded"" },
                        {
                            
                            ""render"": function (data, type, row, meta) {
                                return '<a type=""button"" class=""btn btn-primary btn-sm"" href=""/File/DownloadFile/'+row.id+'"" >Download</a>';
                            }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                return '<a type=""button"" class=""bt");
                    WriteLiteral("n btn-danger btn-sm\" href=\"/File/DeleteFile/\' + row.id +\'\">Delete</a>\';\r\n\r\n                            }\r\n                        }\r\n                    ]\r\n            });\r\n\r\n        } );\r\n\r\n");
                    WriteLiteral("\r\n        </script>\r\n");
                    WriteLiteral(@"        <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.24/js/jquery.dataTables.js""></script>
    
        <!-- File Upload Scripts -->
        <script src=""assets/js/scrollspyNav.js""></script>
        <script src=""plugins/file-upload/file-upload-with-preview.min.js""></script>

        <script>
                        //First upload
                       
        </script>
        <!-- PLUGINS -->

    ");
                }
                );
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DocumentServer.Models.ViewModels.UploadViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
