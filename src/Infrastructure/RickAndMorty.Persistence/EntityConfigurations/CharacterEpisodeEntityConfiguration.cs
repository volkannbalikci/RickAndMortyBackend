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

public class CharacterEpisodeEntityConfiguration : BaseEntityConfiguration<CharacterEpisode>
{
    public override void Configure(EntityTypeBuilder<CharacterEpisode> builder)
    {
        base.Configure(builder);

        builder.ToTable("CharacterEpisode", RickyAndMortyDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Character).WithMany(i => i.CharacterEpisodes).HasForeignKey(i => i.CharacterId);
        builder.HasOne(i => i.Episode).WithMany(i => i.CharacterEpisodes).HasForeignKey(i => i.EpisodeId);
    }
}
