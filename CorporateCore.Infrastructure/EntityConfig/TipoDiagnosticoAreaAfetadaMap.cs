using CorporateCore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace CorporateCore.Infrastructure.EntityConfig
{
    public class TipoDiagnosticoAreaAfetadaMap : IEntityTypeConfiguration<TipoDiagnosticoAreaAfetada>
    {
        public void Configure(EntityTypeBuilder<TipoDiagnosticoAreaAfetada> builder)
        {
            builder.ToTable("tblTipoDiagnosticoAreaAfetada");
            builder.HasKey(t => t.cdTipoDiagnosticoAreaAfetada);
        }
    }
}
