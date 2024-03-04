using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.Infrastructure.Data.SeedDb
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News> 
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            var data = new SeedData();

            builder.HasData(new News[] { data.Vaccine });
        }
    }
}
