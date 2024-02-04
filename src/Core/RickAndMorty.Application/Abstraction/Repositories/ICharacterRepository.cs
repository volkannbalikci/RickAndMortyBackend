using RickAndMorty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Abstraction.Repositories;

public interface ICharacterRepository : IAsyncRepository<Character, int>
{
}
