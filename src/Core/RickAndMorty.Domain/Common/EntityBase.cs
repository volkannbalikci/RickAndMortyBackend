using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Common;

public class EntityBase<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
