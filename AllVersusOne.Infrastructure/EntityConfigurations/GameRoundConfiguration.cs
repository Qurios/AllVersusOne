using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllVersusOne.DataModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllVersusOne.Infrastructure.EntityConfigurations
{
    public class GameRoundConfiguration : IEntityTypeConfiguration<GameRound>
    {
        public void Configure(EntityTypeBuilder<GameRound> builder)
        {
            builder.HasKey(g => g.Id);
        }
    }
}
