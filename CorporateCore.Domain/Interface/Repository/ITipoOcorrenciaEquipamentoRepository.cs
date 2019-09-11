using CorporateCore.Domain.Entity;

namespace CorporateCore.Domain.Interface.Repository
{
    public interface ITipoOcorrenciaEquipamentoRepository : IRepository<TipoOcorrenciaEquipamento>
    {
        SearchEquipamento ConsultaDadosModeloEquipamento(string NumeroSerie, string modeloPai);
    }
}
