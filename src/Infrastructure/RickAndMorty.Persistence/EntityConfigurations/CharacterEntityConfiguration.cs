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

public class CharacterEntityConfiguration : BaseEntityConfiguration<Character>
{
    public override void Configure(EntityTypeBuilder<Character> builder)
    {
        base.Configure(builder);

        builder.ToTable("Character", RickyAndMortyDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.OriginLocation).WithMany(i => i.OriginLocationCharacters).HasForeignKey(i => i.OriginLocationId);
        builder.HasOne(i => i.LastKnownLocation).WithMany(i => i.LastKnownLocationCharacters).HasForeignKey(i => i.LastKnownLocaitonId);  
    }
}
