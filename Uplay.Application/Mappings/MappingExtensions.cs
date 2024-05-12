using AutoMapper;
using Uplay.Application.Models;

namespace Uplay.Application.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedMappedList<T, Y>> PaginatedMappedListAsync<T, Y>(this IQueryable<Y> queryable, IMapper mapper, int pageNumber, int pageSize)
           => PaginatedMappedList<T, Y>.CreateAsync(queryable, mapper, pageNumber, pageSize);
    }
}
