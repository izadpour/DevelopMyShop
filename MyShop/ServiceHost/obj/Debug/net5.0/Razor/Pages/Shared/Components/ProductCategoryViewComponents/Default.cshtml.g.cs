#pragma checksum "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\ProductCategoryViewComponents\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a38acc9675eb31faf63ea05b368648790ddfb3fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.ProductCategoryViewComponents.Pages_Shared_Components_ProductCategoryViewComponents_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/ProductCategoryViewComponents/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.ProductCategoryViewComponents
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a38acc9675eb31faf63ea05b368648790ddfb3fe", @"/Pages/Shared/Components/ProductCategoryViewComponents/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ProductCategoryViewComponents_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_02_MyShopQuery.Contracts.ProductCategoryAgg.ProductCategoryQueryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"category-area section-space\">\r\n    <div class=\"container\">\r\n");
#nullable restore
#line 7 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\ProductCategoryViewComponents\Default.cshtml"
          
        foreach (var productCategory in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  category wrapper  =======-->
                <div class=""category-wrapper"">
                    <div class=""row row-10 masonry-category-layout"">
                        <div class=""col-lg-4 col-sm-6 grid-item"">
                            <!--=======  single category item  =======-->
                            <div class=""single-category-item"">
                                <div class=""single-category-item__image"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a38acc9675eb31faf63ea05b368648790ddfb3fe4536", async() => {
                WriteLiteral("\r\n                                        <img src=\"Theme/assets/img/category/img1-top-eposi1.jpg\" class=\"img-fluid\"");
                BeginWriteAttribute("title", " title=\"", 943, "\"", 980, 1);
#nullable restore
#line 20 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\ProductCategoryViewComponents\Default.cshtml"
WriteAttributeValue("", 951, productCategory.PictureTitle, 951, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 981, "\"", 1014, 1);
#nullable restore
#line 20 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\ProductCategoryViewComponents\Default.cshtml"
WriteAttributeValue("", 987, productCategory.PictureAlt, 987, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"single-category-item__content\">\r\n                                    <h3 class=\"title\">");
#nullable restore
#line 24 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\ProductCategoryViewComponents\Default.cshtml"
                                                 Write(productCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    <a href=""shop-left-sidebar.html"">
                                        <i class=""ion-android-arrow-dropleft-circle""></i> Shop Now
                                    </a>
                                </div>
                            </div>
                            <!--=======  End of single category item  =======-->
                        </div>
                        <div class=""col-lg-4 col-sm-6 grid-item"">
                            <!--=======  single category item  =======-->
                            <div class=""single-category-item"">
                                <div class=""single-category-item__image"">
                                    <a href=""shop-left-sidebar.html"">
                                        <img src=""Theme/assets/img/category/img2-top-eposi1.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 2128, "\"", 2134, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    </a>
                                </div>
                                <div class=""single-category-item__content"">
                                    <h3 class=""title"">Lighting</h3>
                                    <a href=""shop-left-sidebar.html"">
                                        <i class=""ion-android-arrow-dropleft-circle""></i> Shop Now
                                    </a>
                                </div>
                            </div>
                            <!--=======  End of single category item  =======-->
                        </div>
                        <div class=""col-lg-4 col-sm-6 grid-item"">
                            <!--=======  single category item  =======-->
                            <div class=""single-category-item"">
                                <div class=""single-category-item__image"">
                                    <a href=""shop-left-sidebar.html"">
                                      ");
            WriteLiteral("  <img src=\"Theme/assets/img/category/img3-top-eposi1.jpg\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 3235, "\"", 3241, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    </a>
                                </div>
                                <div class=""single-category-item__content"">
                                    <h3 class=""title"">Decoration</h3>
                                    <a href=""shop-left-sidebar.html"">
                                        <i class=""ion-android-arrow-dropleft-circle""></i> Shop Now
                                    </a>
                                </div>
                            </div>
                            <!--=======  End of single category item  =======-->
                        </div>
                        <div class=""col-lg-4 col-sm-6 grid-item"">
                            <!--=======  single category item  =======-->
                            <div class=""single-category-item"">
                                <div class=""single-category-item__image"">
                                    <a href=""shop-left-sidebar.html"">
                                    ");
            WriteLiteral("    <img src=\"Theme/assets/img/category/img4-top-eposi1.jpg\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 4344, "\"", 4350, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    </a>
                                </div>
                                <div class=""single-category-item__content"">
                                    <h3 class=""title"">Living Room</h3>
                                    <a href=""shop-left-sidebar.html"">
                                        <i class=""ion-android-arrow-dropleft-circle""></i> Shop Now
                                    </a>
                                </div>
                            </div>
                            <!--=======  End of single category item  =======-->
                        </div>
                    </div>
                </div>
                <!--=======  End of category wrapper  =======-->
            </div>
        </div>
");
#nullable restore
#line 88 "G:\DevelopMyShop\MyShop\ServiceHost\Pages\Shared\Components\ProductCategoryViewComponents\Default.cshtml"
        }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_02_MyShopQuery.Contracts.ProductCategoryAgg.ProductCategoryQueryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
