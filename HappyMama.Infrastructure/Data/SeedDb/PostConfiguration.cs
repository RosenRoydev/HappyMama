﻿using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyMama.Infrastructure.Data.SeedDb
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            var data = new SeedData();

            builder.HasData(new Post[] {data.ContentForToni,data.AnswerForToni});
        }
    }
    
    
}
