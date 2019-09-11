using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class TipoOcorrencia
    {
        [DataMember]
        public Int16 cdTipOcorrencia { get; set; }
        [DataMember]
        public string deTipOcorrencia { get; set; }
        [DataMember]
        public bool indDelLogic { get; set; }
        [DataMember]
        public bool? indMostraCliente { get; set; }
        [DataMember]
        public bool? indMostraTecnico { get; set; }
        [DataMember]
        public bool? indMostraCallCenter { get; set; }
        [DataMember]
        public bool? indMostraDST { get; set; }
        [DataMember]
        public bool? indMostraSLA { get; set; }
        [DataMember]
        public bool? bitCalcMCBF { get; set; }
        [DataMember]
        public string deMensagemPadrao { get; set; }
        [DataMember]
        public bool? bitAtivacaoAutomatica { get; set; }
        [DataMember]
        public bool? bitPedidoPecaObrigatorio { get; set; }
        [DataMember]
        public bool? bitMostraIndicador { get; set; }
        [DataMember]
        public bool? bitValidoProdutividade { get; set; }
        [DataMember]
        public bool? bitPreventiva { get; set; }
        [DataMember]
        public int? FSA_IDTipOcorrencia { get; set; }
        [DataMember]
        public bool? bitDisponivelOrcamento { get; set; }
        [NotMapped]
        public int codigoFabricante  { get; set; }
        [NotMapped]
        public int codigoSegmento { get; set; }
        [NotMapped]
        public string modeloEquipamento  { get; set; }
        [NotMapped]
        public bool visivelTecnico { get; set; }
        [NotMapped]
        public bool visivelCliente { get; set; }
    }
}
