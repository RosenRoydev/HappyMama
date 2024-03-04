using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyMama.Infrastructure.Data.SeedDb
{
    internal class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            var data = new SeedData();

            builder.HasData(new Theme[] { data.ProblemWithToni });
        }
    }
}
