using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using WorkData.Domain.EntityFramework.EntityFramework.Contexts;
using WorkData.Domain.Permissions.Roles;
using WorkData.Domain.Permissions.UserRoles;
using WorkData.Domain.Permissions.Users;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public static class SeedData
    {
        public static void Initialize(WorkDataContext context)
        {
            context.Database.EnsureCreated();

            if (context.BaseRoles.Any())
                return;

            var baseUser = new BaseUser
            {
                Id = Guid.NewGuid().ToString(),
                IsDelete = false,
                UserName= "administrator",
                UserRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        BaseRole = new BaseRole
                        {
                            Id = Guid.NewGuid().ToString(),
                            RoleName = "超级管理员",
                            Code = "administrator"
                        }
                    }
                }
            };
            baseUser.Password = new PasswordHasher<BaseUser>().HashPassword(baseUser, "password");
            context.BaseUsers.Add(baseUser);

            context.SaveChanges();
        }
    }
}