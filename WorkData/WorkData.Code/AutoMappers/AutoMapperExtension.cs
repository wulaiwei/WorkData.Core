using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WorkData.Dependency;

namespace WorkData.Code.AutoMappers
{
    public static class AutoMapperExtension
    {
        public static IMapper Mapper => IocManager.ServiceLocatorCurrent.GetInstance<IMapper>();

        /// <summary>
        /// AddWorkDataAutoMapper
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddWorkDataAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMapping();
            });

            serviceCollection.AddSingleton<IMapper>(x => new Mapper(mappingConfig));
            return serviceCollection;
        }

        /// <summary>
        /// MapTo
        /// </summary>
        /// <typeparam name="TD"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TD MapTo<TD>(this object source)
        {
            return Mapper.Map<TD>(source);
        }

        /// <summary>
        /// MapTo
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TD MapTo<TS, TD>(this TS source, TD destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}