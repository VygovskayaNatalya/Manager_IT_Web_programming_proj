#pragma checksum "D:\AutoSalon\Views\Home\Announcements.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2da2e8220f5646ee50981b1127b221f9aa53c5f8fbd36851523d20ac15006c6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Home_Announcements), @"mvc.1.0.view", @"/Views/Home/Announcements.cshtml")]
namespace AspNetCoreGeneratedDocument
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\AutoSalon\Views\_ViewImports.cshtml"
using AutoSalon

#nullable disable
    ;
#nullable restore
#line 2 "D:\AutoSalon\Views\_ViewImports.cshtml"
using AutoSalon.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2da2e8220f5646ee50981b1127b221f9aa53c5f8fbd36851523d20ac15006c6a", @"/Views/Home/Announcements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"7bfd870606f08d4bdae53721cc9d57b88bbcc68a4039ba47d78bbe794986e3cb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    internal sealed class Views_Home_Announcements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<
#nullable restore
#line 5 "D:\AutoSalon\Views\Home\Announcements.cshtml"
       List<Auto>

#line default
#line hidden
#nullable disable
    >
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExitCabinet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAuto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("width100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\AutoSalon\Views\Home\Announcements.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"ColumConteinerMainIndex\">\r\n    <div class=\"Line-Logo margin-bottom0 padding-left6\">\r\n        <p class=\"flex-item-400 Gray-085vw\">\r\n            <u class=\"Gray-085vwHover Poiner\"");
            BeginWriteAttribute("onclick", " onclick=\"", 244, "\"", 298, 3);
            WriteAttributeValue("", 254, "location.href=\'", 254, 15, true);
            WriteAttributeValue("", 269, 
#nullable restore
#line 10 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                       Url.Action("Index", "Home")

#line default
#line hidden
#nullable disable
            , 269, 28, false);
            WriteAttributeValue("", 297, "\'", 297, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">Главная</u> / Мои объявления
        </p>
    </div>

    <div class=""Line-Logo shadow gap3"">
        <div class=""ColumConteiner width25"">
            <div class=""LineInfoName border-radius5"">
                <p class=""flex-item Black-Lite-1-5vw""><i class=""fa-solid fa-user User""></i> ");
            Write(
#nullable restore
#line 17 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                                             ViewBag.Surname

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" ");
            Write(
#nullable restore
#line 17 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                                                              ViewBag.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n            </div>\r\n\r\n            <button class=\"my-button-Serch margin-top3\"");
            BeginWriteAttribute("onclick", " onclick=\"", 705, "\"", 763, 3);
            WriteAttributeValue("", 715, "location.href=\'", 715, 15, true);
            WriteAttributeValue("", 730, 
#nullable restore
#line 20 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                                 Url.Action("SubmitAds", "Home")

#line default
#line hidden
#nullable disable
            , 730, 32, false);
            WriteAttributeValue("", 762, "\'", 762, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                <p class=""flex-item White-1-3vw""><i class=""fa-solid fa-car CarGray""></i> Подать объявления</p>
            </button>

            <table class=""margin-top3"">
                <tbody>
                    <tr>
                        <td><p class=""Red-1vw""");
            BeginWriteAttribute("onclick", " onclick=\"", 1042, "\"", 1104, 3);
            WriteAttributeValue("", 1052, "location.href=\'", 1052, 15, true);
            WriteAttributeValue("", 1067, 
#nullable restore
#line 27 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                        Url.Action("Announcements", "Home")

#line default
#line hidden
#nullable disable
            , 1067, 36, false);
            WriteAttributeValue("", 1103, "\'", 1103, 1, true);
            EndWriteAttribute();
            WriteLiteral("><u>Мои объявления</u></p></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td><p class=\"Red-1vw\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1237, "\"", 1293, 3);
            WriteAttributeValue("", 1247, "location.href=\'", 1247, 15, true);
            WriteAttributeValue("", 1262, 
#nullable restore
#line 30 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                        Url.Action("Cabinet", "Home")

#line default
#line hidden
#nullable disable
            , 1262, 30, false);
            WriteAttributeValue("", 1292, "\'", 1292, 1, true);
            EndWriteAttribute();
            WriteLiteral("><u>Мой профиль</u></p></td>\r\n                    </tr>\r\n                    <tr>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2da2e8220f5646ee50981b1127b221f9aa53c5f8fbd36851523d20ac15006c6a9111", async() => {
                WriteLiteral("\r\n                        <td><p class=\"Red-1vw\" id=\"Exit\" onclick=\"submitForm()\"><u>Выход</u></p></td>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </tr>
                </tbody>
            </table>
        </div>

        <div class=""ColumConteiner gap0 width75"">
            <div class=""Line-Logo gap5 width100 margin-bottom0 padding-bottom0 padding-left0"">
                <p class=""flex-item Black-2vw"">Мои объявления</p>
            </div>

            <div class=""Line-Logo gap5 width100 margin-bottom0 padding-bottom0 padding-left0"">
                <div class=""Line-1px gap5 width100 margin-left0 margin-right0""></div>
            </div>


            <div class=""Line-CarBy gap6"">
");
#nullable restore
#line 52 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {
                    if (Model[i].IdUser == int.Parse(ViewBag.IdUser.ToString()))
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <div class=\"ColumForSellAuto width29 padding-left0 margin-bottom5\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 2466, "\"", 2487, 1);
            WriteAttributeValue("", 2472, 
#nullable restore
#line 57 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                       Model[i].Photo

#line default
#line hidden
#nullable disable
            , 2472, 15, false);
            EndWriteAttribute();
            WriteLiteral(" alt=\"Описание изображения\" class=\"Sell-Car-image\" />\r\n\r\n                            <p class=\"flex-item Black-2vw\">");
            Write(
#nullable restore
#line 59 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                            Model[i].Make

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" ");
            Write(
#nullable restore
#line 59 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                           Model[i].Model

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n\r\n                            <p class=\"Black-1vw\"> Цена: ");
            Write(
#nullable restore
#line 61 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                         Model[i].Price

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" $</p>\r\n\r\n                            <div class=\"Line-For-InfoCar background-color\">\r\n                                <p class=\"Black-1vw\">");
            Write(
#nullable restore
#line 64 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                      Model[i].Year

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" год, ");
            Write(
#nullable restore
#line 64 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                          String.Format("{0:0.0}", Model[i].EngineCapacity).Replace(",", ".")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(", ");
            Write(
#nullable restore
#line 64 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                                                                                                Model[i].Mileage

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" км, коробка<br>");
            Write(
#nullable restore
#line 64 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                                                                                                                                 Model[i].Transmission.ToLower()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <button class=\"my-button-Serch\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3111, "\"", 3682, 3);
            WriteAttributeValue("", 3121, "location.href=\'", 3121, 15, true);
            WriteAttributeValue("", 3136, 
#nullable restore
#line 67 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                                     Url.Action("SeeCar", "Home", new {Make = @Model[i].Make, Model = @Model[i].Model,
                                BodyType = @Model[i].BodyType, Year = @Model[i].Year, Price = @Model[i].Price, EngineType = @Model[i].EngineType,
                                Drive  = @Model[i].Drive, Transmission  = @Model[i].Transmission,
                                Description  = @Model[i].Description, Mileage  = @Model[i].Mileage, PhotoUrl  = @Model[i].Photo,EngineCapacity = @String.Format("{0:0.0}", Model[i].EngineCapacity).Replace(",", ".")})

#line default
#line hidden
#nullable disable
            , 3136, 545, false);
            WriteAttributeValue("", 3681, "\'", 3681, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"flex-item White-1-3vw\">от ");
            Write(
#nullable restore
#line 71 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                     Math.Truncate(Math.Pow(double.Parse(Model[i].Price.ToString()), 0.65))

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" р./м</p>\r\n                            </button>\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2da2e8220f5646ee50981b1127b221f9aa53c5f8fbd36851523d20ac15006c6a16515", async() => {
                WriteLiteral("\r\n                                <input hidden type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 4011, "\"", 4035, 1);
                WriteAttributeValue("", 4019, 
#nullable restore
#line 75 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                                                                  Model[i].IdAuto

#line default
#line hidden
#nullable disable
                , 4019, 16, false);
                EndWriteAttribute();
                WriteLiteral(" name=\"IdAuto\">\r\n\r\n                                <button class=\"my-button-Delete\">\r\n                                    <p class=\"flex-item White-1-3vw\">Удалить</p>\r\n                                </button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 82 "D:\AutoSalon\Views\Home\Announcements.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable

            WriteLiteral("            </div>\r\n           \r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    function submitForm() {\r\n        document.getElementById(\'myForm\').submit();\r\n    }\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Auto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
