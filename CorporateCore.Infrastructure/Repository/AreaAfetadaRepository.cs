using CorporateCore.Domain.Entity;
using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace CorporateCore.Infrastructure.Repository
{
    public class AreaAfetadaRepository : EFRepository<AreaAfetada>, IAreaAfetadaRepository
    {
        private readonly CorporateContext context;
        public AreaAfetadaRepository(CorporateContext aval) : base(aval)
        {
            this.context = aval;
        }


    }
}
