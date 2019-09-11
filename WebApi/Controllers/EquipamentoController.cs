using CorporateCore.Domain.Entity;
using CorporateCore.Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller de Equipamentos
    /// </summary>
    [Route("")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly ITipoOcorrenciaEquipamentoService _tipoOcorrenciaEquipamentoService;
        /// <summary>
        /// Adicionar os serviços usados no modulo de equipamento.
        /// </summary>
        /// <param name="tipoOcorrencia"></param>
        public EquipamentoController(ITipoOcorrenciaEquipamentoService tipoOcorrencia)
        {

            _tipoOcorrenciaEquipamentoService = tipoOcorrencia;
        }

        /// <summary>
        /// Consulta os Diagnósticos parametrizados
        /// </summary>
        /// <param name="fabricante"></param>
        /// <param name="codigoSegmento"></param>
        /// <param name="modeloEquipamento"></param>
        /// <param name="numeroSerie"></param>
        /// <param name="visivelTecnico"></param>
        /// <param name="visivelCliente"></param>
        /// <returns></returns>
        /// <response code="200">Retorna lista de diagnósticos</response>
        /// <response code="204">Retorna consulta vazia</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [Route("v1/diagnosticos")]
        [HttpGet]
        public IActionResult Consultar(string fabricante, int? codigoSegmento, string modeloEquipamento = "", string numeroSerie = "", bool? visivelTecnico = null, bool? visivelCliente = null)
        {
            try
            {
                var obj = _tipoOcorrenciaEquipamentoService.Consultar(new TipoOcorrenciaEquipamento
                {
                    ModeloPai = modeloEquipamento,
                    cdSegmento = (byte?)(codigoSegmento != null ? codigoSegmento : null),
                    fabricante = fabricante,
                    mostraCliente = visivelCliente,
                    mostraTecnico = visivelTecnico,
                    Numeroserie = numeroSerie,
                });

                if (obj == null)
                {
                    return NoContent();
                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                var msg = string.Format("API Corporate - Falha na Consulta - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                return this.InternalServerError(new Exception(msg));
            }
        }

        /// <summary>
        /// Consulta os Tipos de Solução por Tipo de Diagnóstico.
        /// </summary>
        /// <param name="codigoTipoDiagnostico"></param>
        /// <param name="codigoTipoDiagnosticoFSA"></param>
        /// <returns></returns>
        /// <response code="400">Falta de preenchimento de campos obrigatórios</response>
        /// <response code="200">Retorna lista de tipos de solução</response>
        /// <response code="204">Retorna consulta vazia</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [Route("v1/solucoes")]
        [HttpGet]
        public IActionResult ConsultarTipoSolucaoPorDiagnostico(int? codigoTipoDiagnostico, int? codigoTipoDiagnosticoFSA)
        {
            try
            {
                if (codigoTipoDiagnostico == null && codigoTipoDiagnosticoFSA == null)
                    return BadRequest("Falta de preenchimento de campos obrigatórios");

                var obj = _tipoOcorrenciaEquipamentoService.ConsultarTipoSolucaoPorDiagnostico(codigoTipoDiagnostico, codigoTipoDiagnosticoFSA);

                if (obj == null)
                {
                    return NoContent();
                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                var msg = string.Format("API Corporate - Falha na Consulta - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                return this.InternalServerError(new Exception(msg));
            }
        }

        /// <summary>
        /// Consulta as Áreas Afetadas por Tipo de Diagnóstico.
        /// </summary>
        /// <param name="codigoTipoDiagnostico"></param>
        /// <param name="codigoTipoDiagnosticoFSA"></param>
        /// <returns></returns>
        /// <response code="400">Falta de preenchimento de campos obrigatórios</response>
        /// <response code="200">Returna lista de áreas afetadas</response>
        /// <response code="204">Retorna consulta vazia</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [Route("v1/areasafetadas")]
        [HttpGet]
        public IActionResult ConsultarAreasAfetadasPorDiagnostico(int? codigoTipoDiagnostico, int? codigoTipoDiagnosticoFSA)
        {
            try
            {
                if (codigoTipoDiagnostico == null && codigoTipoDiagnosticoFSA == null)
                    return BadRequest("Falta de preenchimento de campos obrigatórios");

                var obj = _tipoOcorrenciaEquipamentoService.ConsultarAreasAfetadasPorDiagnostico(codigoTipoDiagnostico, codigoTipoDiagnosticoFSA);

                if (obj == null)
                {
                    return NoContent();
                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                var msg = string.Format("API Corporate - Falha na Consulta - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                return this.InternalServerError(new Exception(msg));
            }
        }
    }
}