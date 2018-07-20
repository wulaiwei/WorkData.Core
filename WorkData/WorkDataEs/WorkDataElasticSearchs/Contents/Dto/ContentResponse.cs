using System.Collections.Generic;
using WorkData.Util.Common.Pages;

namespace WorkDataEs.WorkDataElasticSearchs.Contents.Dto
{
    public class ContentResponse : PageEntity
    {
        public List<Content> Contents { get; set; }

        public List<BrandResponse> BrandResponses { get; set; }

        public List<ClassificationResponse> ClassificationResponses { get; set; }
    }
}