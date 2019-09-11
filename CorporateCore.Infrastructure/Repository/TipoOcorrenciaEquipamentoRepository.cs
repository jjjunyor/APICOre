using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Infrastructure.Data;
using CorporateCore.Domain.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;

namespace CorporateCore.Infrastructure.Repository
{
    public class TipoOcorrenciaEquipamentoRepository : EFRepository<TipoOcorrenciaEquipamento>, ITipoOcorrenciaEquipamentoRepository
    {
        private readonly CorporateContext context;
        public TipoOcorrenciaEquipamentoRepository(CorporateContext aval) : base(aval)
        {
            this.context = aval;
        }

       public SearchEquipamento ConsultaDadosModeloEquipamento(string numeroSerie, string modeloPai)
       {
            var strSql = @"
            SELECT M.cdModelo, M.ModeloPai, M.CdSegmento, M.NmFabricante
            FROM Corporate1..TblParque PA WITH(NOLOCK)
            LEFT JOIN tblModelo M WITH(NOLOCK) ON M.cdModelo = PA.cdModelo
            WHERE (@NumeroSerie IS NULL OR PA.nuNSerie = @NumeroSerie) AND (@ModeloPai IS NULL OR M.ModeloPai = @ModeloPai) ";

            var numeroSerieParam = new SqlParameter("NumeroSerie", numeroSerie);
            var modeloPaiParam = new SqlParameter("ModeloPai", modeloPai);

            if (string.IsNullOrEmpty(numeroSerie))
            {
                numeroSerieParam.Value = DBNull.Value;
            }

            if (string.IsNullOrEmpty(modeloPai))
            {
                modeloPaiParam.Value = DBNull.Value;
            }

            var result = context.SearchEquipamento.FromSql(strSql, numeroSerieParam, modeloPaiParam).FirstOrDefault();
            
            return result;
        }
    }
}
