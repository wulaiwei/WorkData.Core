using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using WorkData.Domain.Permissions.Users;

namespace WorkData.Service.Permissions.Users.Dto
{
    public class BaseUserInputDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public  string Id { get; set; }
    }
}
