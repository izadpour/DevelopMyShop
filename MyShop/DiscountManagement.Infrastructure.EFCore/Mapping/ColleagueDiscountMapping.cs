﻿using DiscountManagement.Domain.ColleaugeDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EFCore.Mapping
{
    public class ColleagueDiscountMapping:IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.HasKey(x => x.Id);
           
        }
    }
}