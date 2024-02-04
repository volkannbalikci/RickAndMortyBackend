using RickAndMorty.Application.Abstraction.Repositories;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Persistence.EntityFramework.Contexts;

namespace RickAndMorty.Persistence.Repositories;

public class EpisodeRepository : EFRepositoryBase<Episode, int, RickyAndMortyDbContext>, IEpisodeRepository
{
    public EpisodeRepository(RickyAndMortyDbContext context) : base(context)
    {
    }
}
