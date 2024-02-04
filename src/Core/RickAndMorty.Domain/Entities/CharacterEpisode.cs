using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities;

public class CharacterEpisode : EntityBase<int>
{
    public int CharacterId { get; set; }
    public int EpisodeId { get; set; }

    public virtual Character Character { get; set; }
    public virtual Episode Episode { get; set; }
}
