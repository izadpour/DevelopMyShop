#pragma checksum "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "740cf81975570c21f9dfb315f01554ff05765ab7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.SlideViewComponents.Pages_Shared_Components_SlideViewComponents_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/SlideViewComponents/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.SlideViewComponents
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
#line 1 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"740cf81975570c21f9dfb315f01554ff05765ab7", @"/Pages/Shared/Components/SlideViewComponents/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_SlideViewComponents_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_02_MyShopQuery.Contracts.SlideAgg.SlideQueryViewModel>>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""hero-slider-area section-space"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  hero slider wrapper  =======-->

                <div class=""hero-slider-wrapper"">
                    <div class=""ht-slick-slider"" data-slick-setting='{
                        ""slidesToShow"": 1,
                        ""slidesToScroll"": 1,
                        ""arrows"": true,
                        ""dots"": true,
                        ""autoplay"": true,
                        ""autoplaySpeed"": 5000,
                        ""speed"": 1000,
                        ""fade"": true,
                        ""infinite"": true,
                        ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                        ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                    }' data-slick-responsive='[
                        {""breakpoint"":1501, ""settin");
            WriteLiteral(@"gs"": {""slidesToShow"": 1} },
                        {""breakpoint"":1199, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":991, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":767, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":575, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                    ]'>

                        <!--=======  single slider item  =======-->
");
#nullable restore
#line 33 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
                          
                            foreach (var slide in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""single-slider-item"">
                                    <div class=""hero-slider-item-wrapper hero-slider-bg-1"">
                                        <div class=""container"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "740cf81975570c21f9dfb315f01554ff05765ab75537", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2093, "~/ProductPictures/", 2093, 18, true);
#nullable restore
#line 39 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
AddHtmlAttributeValue("", 2111, slide.Picture, 2111, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 39 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
AddHtmlAttributeValue("", 2132, slide.PictureAlt, 2132, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 39 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
AddHtmlAttributeValue("", 2158, slide.PictureTitle, 2158, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            <div class=""row"">
                                                <div class=""col-lg-12"">
                                                    <div class=""hero-slider-content hero-slider-content--left-space"">
                                                        <p class=""slider-title slider-title--big-light""> ");
#nullable restore
#line 43 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
                                                                                                    Write(slide.Heading);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                        <p class=\"slider-title slider-title--big-bold\">");
#nullable restore
#line 44 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
                                                                                                  Write(slide.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                                                        <p class=\"slider-title slider-title--small\">\r\n                                                            ");
#nullable restore
#line 46 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
                                                       Write(slide.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </p>\r\n                                                        <a class=\"hero-slider-button\"");
            BeginWriteAttribute("href", " href=\"", 3007, "\"", 3025, 1);
#nullable restore
#line 48 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
WriteAttributeValue("", 3014, slide.Link, 3014, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                                                            ");
#nullable restore
#line 50 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
                                                       Write(slide.BtnText);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                            <i class=""ion-ios-plus-empty""></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
");
#nullable restore
#line 59 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\SlideViewComponents\Default.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        <!--=======  End of single slider item  =======-->


                    </div>
                </div>

                <!--=======  End of hero slider wrapper  =======-->
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_02_MyShopQuery.Contracts.SlideAgg.SlideQueryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591