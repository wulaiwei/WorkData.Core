using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorkData.Code.Repositories;
using WorkData.Code.Webs.Infrastructure;
using WorkData.Domain.WeiXin;
using WorkData.Util.Common.ExceptionExtensions;
using WorkData.Web.Models.OAuths;
using WorkData.Web.Models.WeiXinShare;

namespace WorkData.Web.ApiController
{
    [Route("/api/weiXinShare")]
    public class WeiXinShareController : WorkDataBaseApiController
    {
        private readonly IBaseRepository<WeiXinShare, string> _baseRepository;
        private readonly IBaseRepository<WeiXinUserInfo, string> _weiXinUserInfoRepository;

        public WeiXinShareController(IBaseRepository<WeiXinShare, string> baseRepository, IBaseRepository<WeiXinUserInfo, string> weiXinUserInfoRepository)
        {
            _baseRepository = baseRepository;
            _weiXinUserInfoRepository = weiXinUserInfoRepository;
        }

        /// <summary>
        /// AccessToken
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("saveData")]
        public IActionResult SaveData([FromBody] WeiXinShareViewModel model)
        {
            if (DateTime.Now < Convert.ToDateTime("2018-08-31 23:59:59"))
                return AsErrorJson("活动还未开始！");

            if (DateTime.Now > Convert.ToDateTime("2018-09-07 23:59:59"))
                return AsErrorJson("活动已经结束了！");

            var item = _baseRepository.GetAll()
                .FirstOrDefault(x => x.ShareOpenId == model.ShareOpenId && x.LikeOpenId == model.LikeOpenId);

            if (item!=null)
                return AsErrorJson("你已经点过赞了");

            var share = _weiXinUserInfoRepository.GetAll().FirstOrDefault(x => x.OpenId == model.ShareOpenId);
            var like = _weiXinUserInfoRepository.GetAll().FirstOrDefault(x => x.OpenId == model.LikeOpenId);
            var weiXinShare = new WeiXinShare
            {
                LikeOpenId= model.LikeOpenId,
                LikeOpenNick= like?.NickName,
                ShareOpenId= model.ShareOpenId,
                ShareOpenNick= share?.NickName
            };

            var entity= _baseRepository.Insert(weiXinShare);
            return AsSuccessJson(entity);
        }

        /// <summary>
        /// LoadMyLikeList
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("loadMyLikeList")]
        public IActionResult LoadMyLikeList()
        {
            var shareOpenId = Request.Query["shareOpenId"];
            var data= _baseRepository.GetAll().Where(x => x.ShareOpenId == shareOpenId).Select(x=>x.LikeOpenId).ToList();
            var weiXinUserInfoList = _weiXinUserInfoRepository.GetAll().Where(x => data.Contains(x.OpenId)).ToList();
            return AsSuccessJson(weiXinUserInfoList);
        }

        /// <summary>
        /// LikeRanking
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("likeRanking")]
        public IActionResult LikeRanking()
        {
            var data = _baseRepository.GetAll();
            var item = (from weiXinShare in data
                group weiXinShare by new
                {
                    weiXinShare.ShareOpenId,
                    weiXinShare.ShareOpenNick
                }
                into g
                select new
                {
                    g.Key.ShareOpenId,
                    g.Key.ShareOpenNick,
                    Count = g.Count()
                }).OrderByDescending(x=>x.Count).Take(50).ToList();

            return AsSuccessJson(item);
        }

      
    }
}