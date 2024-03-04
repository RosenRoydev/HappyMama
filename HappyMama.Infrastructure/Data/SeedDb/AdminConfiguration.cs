using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyMama.Infrastructure.Data.SeedDb
{

    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            var data = new SeedData();

            builder.HasData(new Admin[] { data.Admin });
        }
    }

}
