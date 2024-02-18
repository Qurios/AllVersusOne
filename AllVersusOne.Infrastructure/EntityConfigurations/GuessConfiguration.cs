using AllVersusOne.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllVersusOne.Infrastructure.EntityConfigurations
{
    internal class GuessConfiguration : IEntityTypeConfiguration<Guess>
    {
        public void Configure(EntityTypeBuilder<Guess> builder)
        {
            builder.HasKey(g => g.Id);
        }
    }
}
