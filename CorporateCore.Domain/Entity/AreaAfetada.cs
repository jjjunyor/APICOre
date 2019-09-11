using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class AreaAfetada
    {
        [Key]
        [DataMember]
        public int cdAreaAfetada { get; set; }
        [DataMember]
        public string dsAreaAfetada { get; set; }
        [DataMember]
        public bool bitAtivo { get; set; }
    }

    public class AreaAfetadaService
    {
        [DataMember]
        public int CodAreaAfetada { get; set; }
        [DataMember]
        public string DescricaoAreaAfetada { get; set; }
        [DataMember]
        public bool BitAtivo { get; set; }
    }
}
