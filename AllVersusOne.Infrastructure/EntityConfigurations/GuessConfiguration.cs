using AllVersusOne.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
