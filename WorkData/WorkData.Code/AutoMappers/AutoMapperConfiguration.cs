using AutoMapper;
using WorkData.Extensions.TypeFinders;

namespace WorkData.Code.AutoMappers
{
    public static class AutoMapperConfiguration
    {
        public static ITypeFinder TypeFinder => NullTypeFinder.Instance;

        public static IMapperConfigurationExpression AddMapping(
            this IMapperConfigurationExpression configurationExpression)
        {
            var types = TypeFinder.FindClassesOfType<WorkDataBaseProfile>();
            foreach (var itemType in types)
            {
                configurationExpression.AddProfile(itemType);
            }
            return configurationExpression;
        }

    }
}
