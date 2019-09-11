using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class TipoDiagnosticoAreaAfetada
    {
        [DataMember]
        public int cdTipoDiagnosticoAreaAfetada { get; set; }
        [DataMember]
        public string jsonAreasAfetadas { get; set; }
        [DataMember]
        public Int16 cdTipoDiagnostico { get; set; }
        [DataMember]
        public bool bitAtivo { get; set; }
    }
}
