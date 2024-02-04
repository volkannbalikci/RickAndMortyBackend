using RickAndMorty.Application.Utilities.DynamicQuerying.Constants;
using RickAndMorty.Application.Utilities.DynamicQuerying.Implementations;
using RickAndMorty.Application.Utilities.DynamicQuerying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.DynamicQuerying.Extensions;

public static class IQueryableDynamicQueryExtensions
{
    public static IQueryable<T> ToDynamic<T>(this IQueryable<T> query, DynamicQueryRequest dynamicQuery)
    {
        if (dynamicQuery.Filter is not null)
            query = Filter(query, dynamicQuery.Filter);

        if (dynamicQuery.Sorts is not null && dynamicQuery.Sorts.Any())
            query = Sort(query, dynamicQuery.Sorts);

        return query;
    }

    private static IQueryable<T> Filter<T>(IQueryable<T> query, Filter filter)
    {
        List<Filter> filters = GetAllFiters(filter);

        String?[] values = filters.Select(f => f.Value).ToArray();

        String queryString = Transform(filter, filters);

        if (!string.IsNullOrEmpty(queryString) && values is not null)
            query = query.Where(queryString, values);

        return query;
    }

    private static IQueryable<T> Sort<T>(IQueryable<T> query, IEnumerable<Sort> sorts)
    {
        foreach (var sort in sorts)
        {
            if (string.IsNullOrEmpty(sort.Field))
                throw new ArgumentException(DynamicQueryExceptionConstants.InvalidFieldName);
            if (string.IsNullOrEmpty(sort.Direction) || !DynamicQueryLogicConstants.Sorts.Contains(sort.Direction))
                throw new ArgumentException(DynamicQueryExceptionConstants.InvalidSortType);
        }

        if (sorts.Any())
        {
            String orderQueryString = string.Join(separator: ",", values: sorts.Select(s => $"{s.Field} {s.Direction}"));
            return query.OrderBy(orderQueryString);
        }

        return query;
    }

    private static List<Filter> GetAllFiters(Filter filter)
    {
        List<Filter> filters = new List<Filter>();

        SetFilters(filter, filters);

        return filters;
    }

    private static void SetFilters(Filter filter, List<Filter> filters)
    {
        filters.Add(filter);

        if (filter.Filters is not null && filter.Filters.Any())
            foreach (Filter item in filter.Filters)
                SetFilters(item, filters);
    }

    private static String Transform(Filter filter, List<Filter> filters)
    {
        if (string.IsNullOrEmpty(filter.Field))
            throw new ArgumentException(DynamicQueryExceptionConstants.InvalidFieldName);

        if (string.IsNullOrEmpty(filter.Operator) || !DynamicQueryLogicConstants.Operators.ContainsKey(filter.Operator))
            throw new ArgumentException(DynamicQueryExceptionConstants.InvalidCompareOperatorName);

        int index = filters.IndexOf(filter);

        String compareOperator = DynamicQueryLogicConstants.Operators[filter.Operator];

        StringBuilder queryStringBuilder = new StringBuilder();

        if (!string.IsNullOrEmpty(filter.Value))
        {
            if (filter.Operator == DynamicQueryLogicConstants.DoesNotContainsOperatorKeyName)
                queryStringBuilder.Append($"(!np({filter.Field}).{compareOperator}(@{index}))");
            else if (compareOperator == DynamicQueryLogicConstants.StartsWithOperatorValueName || compareOperator == DynamicQueryLogicConstants.EndsWithOperatorValueName || compareOperator == DynamicQueryLogicConstants.ContainsOperatorValueName)
                queryStringBuilder.Append($"(np({filter.Field}).{compareOperator}(@{index}))");
            else
                queryStringBuilder.Append($"np({filter.Field}) {compareOperator} (@{index})");
        }
        else if (filter.Operator == DynamicQueryLogicConstants.IsNullContainsOperatorKeyName || filter.Operator == DynamicQueryLogicConstants.IsNotNullContainsOperatorKeyName)
        {
            queryStringBuilder.Append($"np({filter.Field}) {compareOperator}");
        }

        if (filter.Logic is not null && filter.Filters is not null && filter.Filters.Any())
        {
            if (!DynamicQueryLogicConstants.Logics.Contains(filter.Logic))
                throw new ArgumentException(DynamicQueryExceptionConstants.InvalidLogicalOperatorName);

            return $"{queryStringBuilder} {filter.Logic} ({string.Join(separator: $" {filter.Logic} ", value: filter.Filters.Select(f => Transform(f, filters)).ToArray())})";
        }

        return queryStringBuilder.ToString();
    }
}
