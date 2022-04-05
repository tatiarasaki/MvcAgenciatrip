using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAgenciatrip.Models
{
    public class Promocao
    {
        public int PromocaoId { get; set; }
        public int DestinoId { get; set; }
        public decimal Desconto { get; set; }

        public Destino Destino { get; set; }
    }
}
