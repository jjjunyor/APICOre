using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class SearchEquipamento
    {
        [Key]
        public string cdModelo { get; set; }
        
        public string ModeloPai { get; set; }

        public byte? CdSegmento { get; set; }

        public string NmFabricante { get; set; }
    }

    public class TipoOcorrenciaQuery
    {
        [Key]
        public Int16 cdTipOcorrencia { get; set; }
        public string deTipOcorrencia { get; set; }
    }

}
