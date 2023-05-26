using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PXLApp.TagHelpers
{
    [HtmlTargetElement("span")]
    public class SpanTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "badge bg-dark");
            output.Attributes.SetAttribute("style", "float:center");
        }
    }
}