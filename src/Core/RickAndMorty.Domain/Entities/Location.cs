using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities;

public class Location : EntityBase<int>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Dimension { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }


    public virtual ICollection<LocationResidentCharacter> LocationResidentCharacters { get; set; }
    public virtual ICollection<Character> LastKnownLocationCharacters { get; set; }
    public virtual ICollection<Character> OriginLocationCharacters { get; set; }
}
