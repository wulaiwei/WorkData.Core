using System.Collections.Generic;
using WorkDataEs.WorkDataElasticSearchs.Contents.Dto;

namespace WorkDataEs.WorkDataElasticSearchs.Contents
{
    public interface IContentService
    {
        void Index(Content content, string index);

        void BlukIndex(List<Content> content, string index);

        ContentResponse Search(int pageIndex, int pageSize, RequestContentDto requestContentDto);

        void DeleteByQuery(string key);

        void UpdateByKey(string key, object data);
    }
}