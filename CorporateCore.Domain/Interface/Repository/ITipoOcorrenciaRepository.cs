using CorporateCore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CorporateCore.Domain.Interface.Repository
{
    public interface ITipoOcorrenciaRepository : IRepository<TipoOcorrencia>
    {
        IEnumerable<TipoOcorrenciaQuery> GetAllOcorrencias();
    }
}
