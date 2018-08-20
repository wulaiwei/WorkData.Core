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

        public WeiXinShareController(IBaseRepository<WeiXinShare, string> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// AccessToken
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("saveData")]
        public IActionResult SaveData([FromBody] WeiXinShareViewModel model)
        {
            var item = _baseRepository.GetAll()
                .FirstOrDefault(x => x.ShareOpenId == model.ShareOpenId && x.LikeOpenId == model.LikeOpenId);

            if (item!=null)
                throw new UserFriendlyException($"你已经为{model.ShareOpenNick}点过赞了！");

            var weiXinShare = new WeiXinShare
            {
                LikeOpenId= model.LikeOpenId,
                LikeOpenNick= model.LikeOpenNick,
                ShareOpenId= model.ShareOpenId,
                ShareOpenNick= model.ShareOpenNick
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
            var data= _baseRepository.GetAll().Where(x => x.ShareOpenId == shareOpenId).ToList();
            return AsSuccessJson(data);
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