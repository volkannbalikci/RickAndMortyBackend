using RickAndMorty.Application.Utilities.DynamicQuerying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.DynamicQuerying.Abstractions;

public interface IDynamicQueryRequest
{
    Guid RequestId { get; }
    IEnumerable<Sort>? Sorts { get; set; }
    Filter Filter { get; set; }
}