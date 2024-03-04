using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyMama.Infrastructure.Data.SeedDb
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var data =  new SeedData();

            builder.HasData(new Event[] {data.Christmas});
        }
    }
}
