using Microsoft.EntityFrameworkCore;
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
