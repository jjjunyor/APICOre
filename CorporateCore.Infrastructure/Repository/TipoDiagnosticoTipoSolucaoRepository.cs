using CorporateCore.Domain.Entity;
using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace CorporateCore.Infrastructure.Repository
{
    public class TipoDiagnosticoTipoSolucaoRepository : EFRepository<TipoDiagnosticoTipoSolucao>, ITipoDiagnosticoTipoSolucaoRepository
    {
        private readonly CorporateContext context;
        public TipoDiagnosticoTipoSolucaoRepository(CorporateContext aval) : base(aval)
        {
            this.context = aval;
        }

    }
}
