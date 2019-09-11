using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class TipoSolucao
    {
        [DataMember]
        public Int16 cdGrpSolucao { get; set; }
        [DataMember]
        public Int16 cdTipSolucao { get; set; }
        [DataMember]
        public string deTipSolucao { get; set; }
        [DataMember]
        public bool indDelLogic { get; set; }
        [DataMember]
        public int? FSA_IDSolucao { get; set; }
    }
}
