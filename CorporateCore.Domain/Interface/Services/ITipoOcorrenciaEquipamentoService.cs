using CorporateCore.Domain.Entity;
using System.Collections.Generic;

namespace CorporateCore.Domain.Interface.Services
{
    public interface ITipoOcorrenciaEquipamentoService
    {
        object Consultar(TipoOcorrenciaEquipamento tpOcorrenciaEquipamento);
        List<TipoOcorrencia> GetAllOcorrencias(TipoOcorrencia filtroTipoOcorrencia);

        List<TipoSolucao> ConsultarTipoSolucaoPorDiagnostico(int? codigoTipoDiagnostico, int? codigoTipoDiagnosticoFSA);

        List<AreaAfetada> ConsultarAreasAfetadasPorDiagnostico(int? codigoTipoDiagnostico, int? codigoTipoDiagnosticoFSA);
    }
}
