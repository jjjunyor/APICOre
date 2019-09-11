using CorporateCore.Domain.Entity;
using CorporateCore.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;


namespace CorporateCore.Infrastructure.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CorporateContext>
    {
        public CorporateContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CorporateContext>();

            return new CorporateContext(optionsBuilder.Options);
        }
    }
    public class CorporateContext:DbContext
    {
        public CorporateContext(DbContextOptions<CorporateContext> options):base(options)
        {

        }
       // public DbSet<TipoOcorrencia> tiposOcorrencia { get; set; }
        public DbSet<TipoOcorrencia> tipoOcorrencia { get; set; }
        public DbSet<SearchEquipamento> SearchEquipamento { get; set; }
        public DbSet<TipoOcorrenciaQuery> tipoOcorrenciaQuery { get; set; }
        public DbSet<TipoOcorrenciaEquipamento> tipoOcorrenciaEquipamento { get; set; }
        public DbSet<TipoSolucao> tipoSolucao { get; set; }
        public DbSet<TipoDiagnosticoTipoSolucao> tipoDiagnosticoTipoSolucao { get; set; }
        public DbSet<TipoDiagnosticoAreaAfetada> tipoDiagnosticoAreaAfetada { get; set; }
        public DbSet<AreaAfetada> areaAfetada { get; set; }
        /// <summary>
        /// Responsavel pela configuração do entityFrameWork
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                                                                                                                                              

            //modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new TipoOcorrenciaMap());
            modelBuilder.ApplyConfiguration(new TipoOcorrenciaEquipamentoMap());
            modelBuilder.ApplyConfiguration(new TipoSolucaoMap());
            modelBuilder.ApplyConfiguration(new TipoDiagnosticoTipoSolucaoMap());
            modelBuilder.ApplyConfiguration(new TipoDiagnosticoAreaAfetadaMap());
            modelBuilder.ApplyConfiguration(new AreaAfetadaMap());
        }

    
    }
}
