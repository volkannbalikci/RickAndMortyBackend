using RickAndMorty.Application.Utilities.DynamicQuerying.Abstractions;
using RickAndMorty.Application.Utilities.DynamicQuerying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.DynamicQuerying.Implementations;

public class DynamicQueryRequest : IDynamicQueryRequest
{
    public IEnumerable<Sort>? Sorts { get; set; }
    public Filter Filter { get; set; }

    public Guid RequestId { get; }

    public DynamicQueryRequest()
    {
        RequestId = Guid.NewGuid();
    }

    public DynamicQueryRequest(IEnumerable<Sort>? sorts, Filter filter) : this()
    {
        Sorts = sorts;
        Filter = filter;
    }
}
