using CorporateCore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace CorporateCore.Infrastructure.EntityConfig
{
    public class AreaAfetadaMap : IEntityTypeConfiguration<AreaAfetada>
    {
        public void Configure(EntityTypeBuilder<AreaAfetada> builder)
        {
            builder.ToTable("tblAreaAfetada");
            builder.HasKey(t => t.cdAreaAfetada);
        }
    }
}
