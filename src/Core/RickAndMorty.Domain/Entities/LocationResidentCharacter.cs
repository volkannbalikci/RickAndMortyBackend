using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities
{
    public class LocationResidentCharacter : EntityBase<int>
    {
        public int LocationId { get; set; }
        public int ResidentCharacterId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Character ResidentCharacter { get; set; }
    }
}
