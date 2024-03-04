using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyMama.Infrastructure.Data.SeedDb
{
    internal class ParentConfiguration : IEntityTypeConfiguration <Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            var data = new SeedData();

            builder.HasData(new Parent[] {data.Parent,data.AnotherParent});
             
        }
        

        
    }
}
