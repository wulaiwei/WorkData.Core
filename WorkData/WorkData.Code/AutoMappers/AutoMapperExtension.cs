using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace WorkData.Code.AutoMappers
{
    public static class AutoMapperExtension
    {
        /// <summary>
        /// AddWorkDataAutoMapper
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddWorkDataAutoMapper(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddAutoMapper();
        }
    }
}