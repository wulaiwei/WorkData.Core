// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：HomeController.cs
// 创建标识：吴来伟 2018-05-28 16:49
// 创建描述：
//
// 修改标识：吴来伟2018-06-26 16:12
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorkData.Code.Entities;
using WorkData.Code.Repositories;
using WorkData.Code.ResponseExtensions;
using WorkData.Code.Webs.Infrastructure;
using WorkData.Domain.Permissions.Users;
using WorkData.Domain.WeiXin;
using WorkData.EntityFramework.Extensions;
using WorkData.EntityFramework.Repositories;
using Z.EntityFramework.Plus;

#endregion

namespace WorkData.Web
{
    public class HomeController : WorkDataBaseController
    {
        private readonly IBaseRepository<BaseUser, string> _baseRepository;

        public HomeController(IBaseRepository<BaseUser, string> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        ///     Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _baseRepository.GetAll().ToList();
            _baseRepository.GetAll("CreateUserId","xxx假定不存在的筛选器").ToList();
            _baseRepository.AsNoFilterGetAll().ToList();

            _baseRepository.FindBy("1");
            _baseRepository.FindBy("1", "CreateUserId", "xxx假定不存在的筛选器");
            _baseRepository.AsNoFilterFindBy("1");
            return View();
        }
    }
}