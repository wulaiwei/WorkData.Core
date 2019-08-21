using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using CommonServiceLocator;

namespace WorkData.AutofacServiceLocator
{
    /// <summary>
    /// Autofac implementation of the Microsoft CommonServiceLocator.
    /// </summary>
    public class AutofacServiceLocator : ServiceLocatorImplBase
    {
        /// <summary>
        /// The <see cref="Autofac.IComponentContext"/> from which services
        /// should be located.
        /// </summary>
        private readonly IComponentContext _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="Autofac.Extras.CommonServiceLocator.AutofacServiceLocator" /> class.
        /// </summary>
        /// <param name="container">
        /// The <see cref="Autofac.IComponentContext"/> from which services
        /// should be located.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="container" /> is <see langword="null" />.
        /// </exception>
        public AutofacServiceLocator(IComponentContext container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// Resolves the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be <see langword="null" />.</param>
        /// <returns>The requested service instance.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="serviceType" /> is <see langword="null" />.
        /// </exception>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            return key != null ? _container.ResolveNamed(key, serviceType) : _container.Resolve(serviceType);
        }

        /// <summary>
        /// Resolves all requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <returns>Sequence of service instance objects.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="serviceType" /> is <see langword="null" />.
        /// </exception>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var enumerableType = typeof(IEnumerable<>).MakeGenericType(serviceType);

            var instance = _container.Resolve(enumerableType);
            return ((IEnumerable)instance).Cast<object>();
        }
    }
}