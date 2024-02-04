using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities;

public class Episode : EntityBase<int>
{
    public string Name { get; set; }
    public string AirDate { get; set; }
    public string Code { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }

    public virtual ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
}
