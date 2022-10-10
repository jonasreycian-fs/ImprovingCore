using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("cdrate")]
    public class CDTagHelper : TagHelper
    {
        private readonly IRateService _rateService;

        public string Title { get; set; }
        public string MeterPercent { get; set; }
        public CDTermLength TermLength { get; set; }

        public CDTagHelper(IRateService rateService)
        {
            _rateService = rateService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var rate = _rateService.GetCDRateByTerm(TermLength);

            output.Content.SetContent(
                $@"<div class=""meter"">
                    <p>{Title}</p>
                    <div class=""progress-bar bg-info"" style=""width: {MeterPercent}"">
                    </div>
                </div>"
                );
        }
    }
}
