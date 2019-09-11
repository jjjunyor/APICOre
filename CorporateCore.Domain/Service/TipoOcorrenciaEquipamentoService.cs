using CorporateCore.Domain.Entity;
using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Domain.Interface.Services;
using LinqKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CorporateCore.Domain.Service
{
    public class TipoOcorrenciaEquipamentoService : ITipoOcorrenciaEquipamentoService
    {
        private readonly ITipoOcorrenciaRepository _tipoOcorrenciaRepository;
        private readonly ITipoOcorrenciaEquipamentoRepository _tipoOcorrenciaEquipamentoRepository;
        private readonly ITipoDiagnosticoAreaAfetadaRepository _tipoDiagnosticoAreaAfetadaRepository;
        private readonly ITipoDiagnosticoTipoSolucaoRepository _tipoDiagnosticoTipoSolucaoRepository;
        private readonly ITipoSolucaoRepository _tipoSolucaoRepository;
        private readonly IAreaAfetadaRepository _areaAfetadaRepository;

        public TipoOcorrenciaEquipamentoService(ITipoOcorrenciaEquipamentoRepository tipoOcorrenciaEquipamentoRepository,
            ITipoOcorrenciaRepository tipoOcorrenciaRepository,
            ITipoDiagnosticoAreaAfetadaRepository tipoDiagnosticoAreaAfetadaRepository,
            ITipoDiagnosticoTipoSolucaoRepository tipoDiagnosticoTipoSolucaoRepository,
            ITipoSolucaoRepository tipoSolucaoRepository,
            IAreaAfetadaRepository areaAfetadaRepository
            )
        {
            _tipoOcorrenciaEquipamentoRepository = tipoOcorrenciaEquipamentoRepository;
            _tipoOcorrenciaRepository = tipoOcorrenciaRepository;
            _tipoDiagnosticoAreaAfetadaRepository = tipoDiagnosticoAreaAfetadaRepository;
            _tipoDiagnosticoTipoSolucaoRepository = tipoDiagnosticoTipoSolucaoRepository;
            _tipoSolucaoRepository = tipoSolucaoRepository;
            _areaAfetadaRepository = areaAfetadaRepository;
        }

        /// <summary>
        /// Consultar os tipos de Ocorrencia parametrizadas.
        /// </summary>
        /// <param name="tpOcorrenciaEquipamento"></param>
        /// <returns></returns>
        public object Consultar(TipoOcorrenciaEquipamento tpOcorrenciaEquipamento)
        {
            if (string.IsNullOrEmpty(tpOcorrenciaEquipamento.Numeroserie) && string.IsNullOrEmpty(tpOcorrenciaEquipamento.ModeloPai)
               && tpOcorrenciaEquipamento.cdSegmento == null && string.IsNullOrEmpty(tpOcorrenciaEquipamento.fabricante)
               && tpOcorrenciaEquipamento.mostraTecnico == null)
            {
                var equi = new
                {
                    Fabricante = tpOcorrenciaEquipamento.fabricante,
                    Segmento = tpOcorrenciaEquipamento.cdSegmento,
                    Modelo = tpOcorrenciaEquipamento.ModeloPai != null ? tpOcorrenciaEquipamento.ModeloPai.Trim() : string.Empty,
                    TipoOcorrencia = GetAllOcorrencias(new TipoOcorrencia { indMostraCliente = tpOcorrenciaEquipamento.mostraCliente })
                };

                return equi;
            }
            else
            {

                SearchEquipamento queryModelo = null;

                if (!string.IsNullOrEmpty(tpOcorrenciaEquipamento.Numeroserie))
                {
                    queryModelo = _tipoOcorrenciaEquipamentoRepository.ConsultaDadosModeloEquipamento(tpOcorrenciaEquipamento.Numeroserie, null);
                }
                else if (!string.IsNullOrEmpty(tpOcorrenciaEquipamento.ModeloPai))
                {
                    queryModelo = _tipoOcorrenciaEquipamentoRepository.ConsultaDadosModeloEquipamento(null, tpOcorrenciaEquipamento.ModeloPai);
                }

                if (queryModelo != null)
                {
                    tpOcorrenciaEquipamento.ModeloPai = queryModelo.ModeloPai;
                    tpOcorrenciaEquipamento.cdSegmento = tpOcorrenciaEquipamento.cdSegmento ?? queryModelo.CdSegmento;
                    tpOcorrenciaEquipamento.fabricante = tpOcorrenciaEquipamento.fabricante ?? queryModelo.NmFabricante;
                }

                var listEquipamentoModelo = _tipoOcorrenciaEquipamentoRepository.Buscar(x => x.bitAtivo == true
                                                    && x.ModeloPai == tpOcorrenciaEquipamento.ModeloPai).ToList();

                var listEquipamentoSegmento = _tipoOcorrenciaEquipamentoRepository.Buscar(x => x.bitAtivo == true
                                                    && x.ModeloPai == null
                                                    && x.cdSegmento == tpOcorrenciaEquipamento.cdSegmento).ToList();

                var listEquipamentoFabricante = _tipoOcorrenciaEquipamentoRepository.Buscar(x => x.bitAtivo == true
                                                    && x.ModeloPai == null
                                                    && x.cdSegmento == null
                                                    && x.fabricante == tpOcorrenciaEquipamento.fabricante).ToList();

                var listEquipamento = (_tipoOcorrenciaEquipamentoRepository.Buscar(x => x.bitAtivo == true &&
                (
                   tpOcorrenciaEquipamento.ModeloPai == "" || x.ModeloPai == tpOcorrenciaEquipamento.ModeloPai
                )
                &&
                (
                    x.cdSegmento == tpOcorrenciaEquipamento.cdSegmento || tpOcorrenciaEquipamento.cdSegmento == null
                )
                &&
                (
                    x.fabricante == tpOcorrenciaEquipamento.fabricante || tpOcorrenciaEquipamento.fabricante == null
                )
                )).ToList();

                var equipamentos = new List<TipoOcorrenciaEquipamento>();

                equipamentos.AddRange(listEquipamentoModelo);
                equipamentos.AddRange(listEquipamentoSegmento);
                equipamentos.AddRange(listEquipamentoFabricante);
                equipamentos.AddRange(listEquipamento);

                if (equipamentos == null || equipamentos.Count == 0)
                    return null;

                var idsTipoOcorrencia = new List<short?>();
                var tipOcorrenciaEqui = new List<TipoOcorrenciaFSA>();

                foreach (TipoOcorrenciaEquipamento ocEqui in equipamentos)
                {
                    tipOcorrenciaEqui = JsonConvert.DeserializeObject<List<TipoOcorrenciaFSA>>(ocEqui.jsonTipoOcorrencia);
                    if (tipOcorrenciaEqui != null)
                    {
                        idsTipoOcorrencia.AddRange(tipOcorrenciaEqui.Select(x => x.CodigoTipOcorrencia));
                    }
                }

                var tiposOcorrencia = _tipoOcorrenciaRepository.Buscar(x => idsTipoOcorrencia.Distinct().Contains(x.cdTipOcorrencia)).ToList();

                if (tpOcorrenciaEquipamento.mostraCliente != null && (bool)tpOcorrenciaEquipamento.mostraCliente)
                    tiposOcorrencia = tiposOcorrencia.Where(x => x.indMostraCliente == true).ToList();

                if (tpOcorrenciaEquipamento.mostraTecnico != null && (bool)tpOcorrenciaEquipamento.mostraTecnico)
                    tiposOcorrencia = tiposOcorrencia.Where(x => x.indMostraTecnico == true).ToList();

                var equipamento = equipamentos.FirstOrDefault();

                var equi = new
                {
                    Fabricante = equipamento.fabricante,
                    Segmento = equipamento.cdSegmento,
                    Modelo = equipamento.ModeloPai != null ? equipamento.ModeloPai.Trim() : string.Empty,
                    TipoOcorrencia = tiposOcorrencia
                };

                return equi;
            }
        }

        public List<AreaAfetada> ConsultarAreasAfetadasPorDiagnostico(int? codigoTipoDiagnostico, int? codigoTipoDiagnosticoFSA)
        {
            if (codigoTipoDiagnosticoFSA.HasValue && !codigoTipoDiagnostico.HasValue)
            { 
                var tipoOcorrenciaFSA = _tipoOcorrenciaRepository.Buscar(x => x.FSA_IDTipOcorrencia == codigoTipoDiagnosticoFSA).FirstOrDefault();

                if (tipoOcorrenciaFSA != null)
                {
                    codigoTipoDiagnostico = tipoOcorrenciaFSA.cdTipOcorrencia;
                }
            }

            TipoDiagnosticoAreaAfetada tipoDiagnosticoAreaAfetada = _tipoDiagnosticoAreaAfetadaRepository.Buscar(x => x.cdTipoDiagnostico == codigoTipoDiagnostico).FirstOrDefault();

            List<AreaAfetada> areaAfetadas = null;
            if (tipoDiagnosticoAreaAfetada != null)
            {
                List<AreaAfetadaService> jsonAreasAfetadas = JsonConvert.DeserializeObject<List<AreaAfetadaService>>(tipoDiagnosticoAreaAfetada.jsonAreasAfetadas);

                areaAfetadas = new List<AreaAfetada>();

                foreach (var item in jsonAreasAfetadas)
                {
                    AreaAfetada obj = new AreaAfetada();

                    obj = _areaAfetadaRepository.Buscar(x => x.cdAreaAfetada == item.CodAreaAfetada).FirstOrDefault();
                    areaAfetadas.Add(obj);
                }
            }
            return areaAfetadas;
        }

        public List<TipoSolucao> ConsultarTipoSolucaoPorDiagnostico(int? codigoTipoDiagnostico, int? codigoTipoDiagnosticoFSA)
        {
            if (codigoTipoDiagnosticoFSA.HasValue && !codigoTipoDiagnostico.HasValue)
            {
                var tipoOcorrenciaFSA = _tipoOcorrenciaRepository.Buscar(x => x.FSA_IDTipOcorrencia == codigoTipoDiagnosticoFSA).FirstOrDefault();

                if (tipoOcorrenciaFSA != null)
                {
                    codigoTipoDiagnostico = tipoOcorrenciaFSA.cdTipOcorrencia;
                }
            }

            TipoDiagnosticoTipoSolucao tipoDiagnosticoTpSolucao = _tipoDiagnosticoTipoSolucaoRepository.Buscar(x => x.cdTipoDiagnostico == codigoTipoDiagnostico).FirstOrDefault();

            List<TipoSolucao> solucoes = null;
            if (tipoDiagnosticoTpSolucao != null)
            {
                List<TipoSolucao> jsonTipSolucao = JsonConvert.DeserializeObject<List<TipoSolucao>>(tipoDiagnosticoTpSolucao.jsonTipoSolucao);

                solucoes = new List<TipoSolucao>();

                foreach (var item in jsonTipSolucao)
                {
                    TipoSolucao obj = new TipoSolucao();

                    obj = _tipoSolucaoRepository.Buscar(x => x.cdTipSolucao == item.cdTipSolucao).FirstOrDefault();
                    solucoes.Add(obj);
                }

            }
            return solucoes;
        }

        /// <summary>
        /// Consulta os Tipos de ocorrencia
        /// </summary>
        /// <param name="filtroTipoOcorrencia"></param>
        /// <returns></returns>
        public List<TipoOcorrencia> GetAllOcorrencias(TipoOcorrencia filtroTipoOcorrencia)
        {
            var predicate = (Expression<Func<TipoOcorrencia, bool>>)(x => x.indDelLogic == false);

            if (filtroTipoOcorrencia.indMostraCliente != null)
            {
                predicate = predicate.And(x => x.indMostraCliente == filtroTipoOcorrencia.indMostraCliente);
            }

            return _tipoOcorrenciaRepository.Buscar(predicate).ToList();
        }
    }
}
