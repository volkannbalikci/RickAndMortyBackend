using RickAndMorty.Application.RickAndMortyApi.Models;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Pagination.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.Pagination.Extensions;

public static class IQueryablePaginationExtensions
{
    public static IPagination<T> ToPagination<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        int totalCount = source.Count();

        List<T> items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();

        return new Pagination<T>(items, pageIndex, pageSize);
    }

    public static async Task<IPagination<T>> ToPaginationAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        int totalCount = source.Count();

        List<T> items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();

        return await Task.FromResult(new Pagination<T>(items, pageIndex, pageSize));
    }
}


public static class ListPaginationExtensions
{
    public static IPagination<T> ToPagination<T>(this List<T> source, int pageIndex, int pageSize)
    {
        int totalCount = source.Count();

        List<T> items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();

        return new Pagination<T>(items, pageIndex, pageSize);
    }

    public static async Task<IPagination<T>> ToPaginationAsync<T>(this List<T> source, int pageIndex, int pageSize)
    {
        int totalCount = source.Count();

        List<T> items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();

        return await Task.FromResult(new Pagination<T>(items, pageIndex, pageSize));
    }

    public static async Task<IPagination<T>> ToPaginationAsync<T>(this List<T> source, int pageIndex, int pageSize, int sourceTotalCount)
    {
        int count = sourceTotalCount;
        List<T> items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        Pagination<T> pagination = new()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalCount = count,
            Items = items,
            TotalPageCount = (int)Math.Ceiling(count / (double)pageSize)
        };
        return await Task.FromResult(pagination);
    }
}
