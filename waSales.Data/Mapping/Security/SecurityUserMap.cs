﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Security;


namespace waSales.Data.Mapping.Security
{
    public class SecurityUserMap : IEntityTypeConfiguration<SecurityUser>
    {
        public void Configure(EntityTypeBuilder<SecurityUser> builder)
        {
            builder.ToTable("SecurityUser")
            .HasKey(c => c.Id);
        }
    }
}
