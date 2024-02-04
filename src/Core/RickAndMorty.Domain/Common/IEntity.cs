using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Common;

public interface IEntity<TId>
{
    TId Id { get; set; }
    DateTime CreatedDate { get; set; }
}
