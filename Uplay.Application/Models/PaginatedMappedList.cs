﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Uplay.Application.Models
{
    public sealed class PaginatedMappedList<T, Y> // T - Dto, Y - Entity
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginatedMappedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedMappedList<T, Y>> CreateAsync(IQueryable<Y> source, IMapper mapper, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var dtos = mapper.Map<List<Y>, List<T>>(items);

            return new PaginatedMappedList<T, Y>(dtos, count, pageIndex, pageSize);
        }
    }

}
