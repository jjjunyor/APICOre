using CorporateCore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace CorporateCore.Infrastructure.EntityConfig
{
    public class TipoSolucaoMap : IEntityTypeConfiguration<TipoSolucao>
    {
        public void Configure(EntityTypeBuilder<TipoSolucao> builder)
        {
            builder.ToTable("tblTipoSolucao");
            builder.HasKey(t => t.cdTipSolucao);
        }
    }
}
