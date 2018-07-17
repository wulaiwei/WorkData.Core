// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：IResolver.cs
// 创建标识：吴来伟 2017-11-23 11:37
// 创建描述：
//
// 修改标识：吴来伟2017-11-23 11:41
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;

#endregion

namespace WorkData.Dependency
{
    public interface IResolver
    {
        /// <summary>
        ///     Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>(ILifetimeScope scope = null);

        /// <summary>
        ///     Determines whether this instance is registered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///     <c>true</c> if this instance is registered; otherwise, <c>false</c>.
        /// </returns>
        bool IsRegistered<T>() where T : class;

        /// <summary>
        ///     Determines whether the specified type is registered.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="scope">The ILifetimeScope</param>
        /// <returns>
        ///     <c>true</c> if the specified type is registered; otherwise, <c>false</c>.
        /// </returns>
        bool IsRegistered(Type type, ILifetimeScope scope = null);

        /// <summary>
        /// Releases a pre-resolved object. See Resolve methods.
        /// </summary>
        /// <param name="obj">Object to be released</param>
        void Release(object obj);

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        T Resolve<T>(IEnumerable<Parameter> parameters, ILifetimeScope scope = null);

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T ResolveParameter<T>(params Parameter[] parameters);

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T ResolveName<T>(string name);

        /// <summary>
        /// Resolve
        /// </summary>
        /// <returns></returns>
        object Resolve(Type type);
    }
}