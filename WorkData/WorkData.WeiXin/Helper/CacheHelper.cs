using System;
using Microsoft.AspNetCore.Http;

namespace WorkData.WeiXin.Helper
{
    /// <summary>
    /// 服务器缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 创建缓存项的文件依赖
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="fileName">文件绝对路径</param>
        public static void InsertFile(string key, object obj, string fileName)
        {
            //创建缓存依赖项
            var dep = new CacheDependency(fileName);
            //创建缓存
            HttpContext.Current.Cache.Insert(key, obj, dep);
        }

        /// <summary>
        /// 创建缓存项过期
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="expires">设置时间</param>
        public static void Insert(string key, object obj, int expires)
        {
            if (obj != null)
            {
                HttpContext.Current.Cache.Insert(key, obj, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, expires, 0));
            }
        }

        /// <summary>
        /// 判断缓存对象是否存在
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        /// <returns>是否存在true 、false</returns>
        public static bool IsExist(string strKey)
        {
            return HttpContext.Current != null && HttpContext.Current.Cache[strKey] != null;
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>object对象</returns>
        public static object GetCache(string key)
        {
            return string.IsNullOrEmpty(key) ? 
                null :
                HttpContext.Current.Cache.Get(key);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">T对象</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            var obj = GetCache(key);
            return obj == null ? default(T) : (T)obj;
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">缓存Key</param>
        public static void RemoveAllCache(string cacheKey)
        {
            var cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            var cache = HttpRuntime.Cache;
            var cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}