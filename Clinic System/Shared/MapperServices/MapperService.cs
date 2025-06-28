using MapsterMapper;
using Mapster;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagmentSystem.Shared.MapperServices
{
    public static class MapperService
    {
        public static IMapper Mapper { get; set; }

        public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source)
        {
            return source.ProjectToType<TDestination>(Mapper.Config);
        }


        public static IEnumerable<TDestination> ProjectEnumerableTo<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return source.AsQueryable().ProjectToType<TDestination>(Mapper.Config).ToList();
        }


        public static TDestination Map<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
