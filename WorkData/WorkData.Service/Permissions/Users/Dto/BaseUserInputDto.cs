using System;
using System.Collections.Generic;
using System.Text;

namespace WorkData.Service.Permissions.Users.Dto
{
    public class BaseUserInputDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public  string Id { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 加密盐
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
