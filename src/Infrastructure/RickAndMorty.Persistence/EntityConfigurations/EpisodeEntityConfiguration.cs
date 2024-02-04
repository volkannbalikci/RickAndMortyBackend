using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Persistence.EntityConfigurations;

public class EpisodeEntityConfiguration : BaseEntityConfiguration<Episode>
{
    public override void Configure(EntityTypeBuilder<Episode> builder)
    {
        base.Configure(builder);

        builder.ToTable("Episode", RickyAndMortyDbContext.DEFAULT_SCHEMA);

    }
}
