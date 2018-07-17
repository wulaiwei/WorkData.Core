// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：UnitOfWork.cs
// 创建标识：吴来伟 2017-11-27 11:04
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 11:04
// 修改描述：
//  ------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        /// <summary>
        /// Begin
        /// </summary>
        public virtual void Begin()
        {
        }

        /// <summary>
        /// ComplateUnit
        /// </summary>
        public void Complate()
        {
            ComplateUnit();
        }

        /// <summary>
        /// ComplateUnitAsync
        /// </summary>
        /// <returns></returns>
        public async Task CompleteAsync()
        {
            await ComplateUnitAsync();
        }

        private bool _disposed;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (!disposing) return;
            try
            {
                DisposeUnit();
                _disposed = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"dispose unitofwork is error, error reason is {ex}");
            }
        }

        /// <summary>
        /// ComplateUnit
        /// </summary>
        protected abstract void ComplateUnit();

        /// <summary>
        /// ComplateUnitAsync
        /// </summary>
        /// <returns></returns>
        protected abstract Task ComplateUnitAsync();

        /// <summary>
        /// DisposeUnit
        /// </summary>
        protected abstract void DisposeUnit();

        /// <summary>
        /// SaveChanges
        /// </summary>
        public abstract void SaveChanges();

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        public abstract Task SaveChangesAsync();
    }
}