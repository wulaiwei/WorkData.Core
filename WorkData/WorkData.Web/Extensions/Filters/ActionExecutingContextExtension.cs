using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WorkData.Web.Extensions.Filters
{
    public static class ActionExecutingContextExtension
    {
        public static T TypeOfAttributeEntity<T>(this ActionExecutingContext context) where T : Attribute
        {
            return (context?.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo
                .GetCustomAttribute<T>();
        }
    }
}