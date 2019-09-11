using CorporateCore.Domain.Entity;
using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace CorporateCore.Infrastructure.Repository
{
    public class TipoOcorrenciaRepository : EFRepository<TipoOcorrencia>, ITipoOcorrenciaRepository
    {
        private readonly CorporateContext context;
        public TipoOcorrenciaRepository(CorporateContext aval) : base(aval)
        {
            this.context = aval;
        }

        public IEnumerable<TipoOcorrenciaQuery> GetAllOcorrencias()
        {
            var strSQl = "SELECT  cdTipOcorrencia  , deTipOcorrencia " +
                         " FROM  tblTipoOcorrencia  WHERE  indDelLogic = 0   AND indMostraCliente = 1 ";

            var result = context.tipoOcorrenciaQuery.FromSql<TipoOcorrenciaQuery>(strSQl).ToList();

            return result;
        }
    }
}
