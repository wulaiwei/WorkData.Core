using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WorkData;
using WorkData.Dependency;
using WorkData.ElasticSearch.Config;
using WorkData.Extensions.TypeFinders;
using WorkDataEs.WorkDataElasticSearchs.Contents;
using WorkDataEs.WorkDataElasticSearchs.Contents.Dto;

namespace WorkDataEs
{
    internal class Program
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();

        public static List<Content> Contents { get; set; }

        private static void Main(string[] args)
        {
            #region 初始化

            var paths = new List<string>
            {
                "Config/moduleConfig.json",
                "Config/commonConfig.json"
            };
            BootstrapWarpper.InitiateConfig(paths,null);

            #endregion 初始化

            //初始化service
            var service = IocManager.ServiceLocatorCurrent.GetInstance<IContentService>();
            //初始化service
            var service1 = IocManager.ServiceLocatorCurrent.GetInstance<ITypeFinder>();
            //初始化预置数据
            Contents = InitData();
            //赋值
            //service.BlukIndex(Contents, "content_test");

            //复杂查询
            var request = new RequestContentDto
            {
                PageSize = 5,
                SearchKey = "赛乐"
            };

            #region 高亮

            var highlightConfig = new HighlightConfig<Content>
            {
                Tag = "i",
                HighlightConfigExpression = new List<Expression<Func<Content, object>>>
                {
                    x=>x.Title
                }
            };
            request.HighlightConfigEntity = highlightConfig;

            var data = service.Search(request.CurrentIndex, request.PageSize, request);

            //删除
            service.DeleteByQuery("123852");

            //更新
            service.UpdateByKey("123754", new Content
            {
                Key = "123"
            });

            #endregion 高亮
        }

        #region 初始化数据

        /// <summary>
        /// InitData
        /// </summary>
        /// <returns></returns>
        private static List<Content> InitData()
        {
            return new List<Content>
            {
                new Content
                {
                    Key="123852",
                    Title="康尔 KingCamp 碳纤维登山杖 碳素手杖 户外徒步 轻 外锁KA4665",
                    ImgUrl= "https://m.360buyimg.com/babel/jfs/t7699/154/4235664957/46882/ab720071/5a082a42N0f424779.jpg",
                    Code="2495868",
                    UnitPrice= 199.0M,
                    BaseType= "JdBulkindustrial",
                    ClassificationName= "登山攀岩",
                    ClassificationCode= ",1,1862,1917,1930,",
                    BrandFirstLetters= "K",
                    Brand= "康尔（KingCamp）",
                    BelongMemberName= "成都京东世纪贸易有限公司",
                    IsSelfSupport= 0,
                    ResourceStatus= 1,
                    BrandGroupBy= "康尔（KingCamp）&K",
                    ClassificationGroupBy= "登山攀岩&,1,1862,1917,1930,"
                },
                new Content
                {
                   Key="123754",
                   Title="赛乐（Zealwood）银离子吸湿排汗防脚臭跑步骑行功能袜TREK LT系列17017 Z084M 墨绿色一双装",
                   ImgUrl="https://m.360buyimg.com/babel/jfs/t12136/106/885881193/94278/adda7271/5a164d21Ncde2321a.jpg",
                   Code="5899056",
                   UnitPrice=49.0M,
                   BaseType="JdBulkindustrial",
                   ClassificationName="户外袜",
                   ClassificationCode=",1,1862,1896,1899,",
                   BrandFirstLetters="Z",
                   Brand="ZEAL WOOD",
                   BelongMemberName="成都京东世纪贸易有限公司",
                   IsSelfSupport=0,
                   ResourceStatus=1,
                   BrandGroupBy="ZEAL WOOD&Z",
                   ClassificationGroupBy="户外袜&,1,1862,1896,1899,"
                },
                new Content
                {
                   Key= "123753",
                   Title= "赛乐（Zealwood）椰碳纤维登山徒步吸湿排汗功能袜ACTIVE系列17012 Z081M 黑蓝色一双装",
                   ImgUrl= "https://m.360buyimg.com/babel/jfs/t12802/305/908277128/85492/a064e452/5a164b94Nfd9daf87.jpg",
                   Code= "5815969",
                   UnitPrice= 39.0M,
                   BaseType= "JdBulkindustrial",
                   ClassificationName= "户外袜",
                   ClassificationCode= ",1,1862,1896,1899,",
                   BrandFirstLetters= "Z",
                   Brand= "ZEAL WOOD",
                   BelongMemberName= "成都京东世纪贸易有限公司",
                   IsSelfSupport= 0,
                   ResourceStatus= 1,
                   BrandGroupBy= "ZEAL WOOD&Z",
                   ClassificationGroupBy= "户外袜&,1,1862,1896,1899,"
                },
                new Content
                {
                    Key="123795",
                    Title="红色营地 户外铝合金登山杖 便携徒步健走杖 拐杖 直把 红色",
                    ImgUrl="https://m.360buyimg.com/babel/jfs/t3631/98/575860737/76998/8e120f1e/580da7b5N156b74e4.jpg",
                    Code="1084302",
                    UnitPrice=29.0M,
                    BaseType="JdBulkindustrial",
                    ClassificationName="登山攀岩",
                    ClassificationCode=",1,1862,1917,1930,",
                    BrandFirstLetters="G",
                    Brand="红色营地",
                    BelongMemberName="成都京东世纪贸易有限公司",
                    IsSelfSupport=0,
                    ResourceStatus=1,
                    BrandGroupBy="红色营地&G",
                    ClassificationGroupBy="登山攀岩&,1,1862,1917,1930,"
                },
                new Content
                {
                   Key="123797",
                   Title="红色营地 户外铝合金登山杖 便携徒步健走杖 拐杖 T型 红色",
                   ImgUrl="https://m.360buyimg.com/babel/jfs/t20161/327/430422201/70069/d06bc66d/5b0e090cN7e077a21.jpg",
                   Code="1084306",
                   UnitPrice=33.0M,
                   BaseType="JdBulkindustrial",
                   ClassificationName="登山攀岩",
                   ClassificationCode=",1,1862,1917,1930,",
                   BrandFirstLetters="G",
                   Brand="红色营地",
                   BelongMemberName="成都京东世纪贸易有限公司",
                   IsSelfSupport=0,
                   ResourceStatus=1,
                   BrandGroupBy="红色营地&G",
                   ClassificationGroupBy="登山攀岩&,1,1862,1917,1930,"
                }
            };
        }

        #endregion 初始化数据
    }
}