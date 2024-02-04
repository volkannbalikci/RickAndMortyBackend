using RickAndMorty.Application.Abstraction.Repositories;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Persistence.EntityFramework.Contexts;

namespace RickAndMorty.Persistence.Repositories;

public class LocationRepository : EFRepositoryBase<Location, int, RickyAndMortyDbContext>, ILocationRepository
{
    public LocationRepository(RickyAndMortyDbContext context) : base(context)
    {
    }
}
