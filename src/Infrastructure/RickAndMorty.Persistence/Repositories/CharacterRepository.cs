using RickAndMorty.Application.Abstraction.Repositories;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Persistence.Repositories;

public class CharacterRepository : EFRepositoryBase<Character, int, RickyAndMortyDbContext>, ICharacterRepository
{
    public CharacterRepository(RickyAndMortyDbContext context) : base(context)
    {
    }
}
