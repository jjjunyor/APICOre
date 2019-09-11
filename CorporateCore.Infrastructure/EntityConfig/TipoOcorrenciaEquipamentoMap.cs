using CorporateCore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace CorporateCore.Infrastructure.EntityConfig
{
    public class TipoOcorrenciaEquipamentoMap : IEntityTypeConfiguration<TipoOcorrenciaEquipamento>
    {
        public void Configure(EntityTypeBuilder<TipoOcorrenciaEquipamento> builder)
        {

            builder.ToTable("tblTipoOcorrenciaEquipamento");
            builder.HasKey(t => t.cdTipoOcorrenciaEquipamento);
        }
    }
}
