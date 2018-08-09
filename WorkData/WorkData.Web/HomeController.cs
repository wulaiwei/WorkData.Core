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

using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Code.Repositories;
using WorkData.Code.UnitOfWorks;
using WorkData.Dependency;
using WorkData.Domain.EntityFramework.EntityFramework.Sessions;
using WorkData.Domain.Permissions.Users;
using WorkData.EntityFramework.Auditables;
using WorkData.Web.Extensions.Infrastructure;

#endregion

namespace WorkData.Web
{
    public class HomeController : WorkDataBaseController
    {
        private readonly IBaseRepository<BaseUser, string> _baseUserRepository;

        public HomeController(IBaseRepository<BaseUser, string> baseUserRepository)
        {
            _baseUserRepository = baseUserRepository;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var user=new BaseUser();
            _baseUserRepository.Insert(user);
            return View();
        }
    }
}