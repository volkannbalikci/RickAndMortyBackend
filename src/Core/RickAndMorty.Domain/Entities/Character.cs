using RickAndMorty.Domain.Common;
using RickAndMorty.Domain.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities;

public class Character : EntityBase<int>
{
    public int OriginLocationId { get; set; }
    public int LastKnownLocaitonId { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public Gender Gender { get; set; }
    public string ImageUrl { get; set; }
    public string Url { get; set; }
    public DateTime Created  { get; set; }

    public virtual ICollection<LocationResidentCharacter> LocationResidentCharacters { get; set; }
    public virtual ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
    public virtual Location OriginLocation { get; set; }
    public virtual Location LastKnownLocation { get; set; }

}
