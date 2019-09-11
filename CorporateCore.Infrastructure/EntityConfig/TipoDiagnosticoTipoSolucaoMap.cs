using CorporateCore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace CorporateCore.Infrastructure.EntityConfig
{
    public class TipoDiagnosticoTipoSolucaoMap : IEntityTypeConfiguration<TipoDiagnosticoTipoSolucao>
    {
        public void Configure(EntityTypeBuilder<TipoDiagnosticoTipoSolucao> builder)
        {
            builder.ToTable("tblTipoDiagnosticoTipoSolucao");
            builder.HasKey(t => t.cdTipoDiagnosticoTipoSolucao);
        }
    }
}
