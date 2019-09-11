using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateCore.Domain.Entity
{
    public class TipoOcorrenciaEquipamento
    {
        [Key]
        public int? cdTipoOcorrenciaEquipamento { get; set; }
        public string fabricante { get; set; }
        public Byte? cdSegmento { get; set; }
        public string ModeloPai { get; set; }
        public string jsonTipoOcorrencia { get; set; }
        public bool? bitAtivo { get; set; }
        [NotMapped]
        public bool? mostraCliente { get; set; }
        [NotMapped]
        public bool? mostraTecnico { get; set; }
        [NotMapped]
        public string Numeroserie { get; set; }
    }
}
