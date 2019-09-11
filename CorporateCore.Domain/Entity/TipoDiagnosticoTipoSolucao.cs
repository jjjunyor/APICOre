using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class TipoDiagnosticoTipoSolucao
    {
        [DataMember]
        public int cdTipoDiagnosticoTipoSolucao { get; set; }
        [DataMember]
        public Int16 cdTipoDiagnostico { get; set; }
        [DataMember]
        public string jsonTipoSolucao { get; set; }
        [DataMember]
        public bool bitAtivo { get; set; }
    }
}
