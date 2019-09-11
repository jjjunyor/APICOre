using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Domain.Interface.Services;

namespace CorporateCore.Domain.Service
{
    public class TipoOcorrenciaService : ITipoOcorrenciaService
    {
        private readonly ITipoOcorrenciaRepository _tipoOcorrenciaRepository;
        private readonly ITipoOcorrenciaEquipamentoRepository _tipoOcorrenciaEquipamentoRepository;

        public TipoOcorrenciaService(ITipoOcorrenciaRepository contaRepository, ITipoOcorrenciaEquipamentoRepository tipoOcorrenciaEquipamentoRepository)
        {
            this._tipoOcorrenciaRepository = contaRepository;
            this._tipoOcorrenciaEquipamentoRepository = tipoOcorrenciaEquipamentoRepository;
        }
    }
}
