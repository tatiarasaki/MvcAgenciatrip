using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAgenciatrip.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        
        [StringLength(50)] 
        public string Nome { get; set; }
        
        [StringLength(50)] 
        public string Sobrenome { get; set; }
        
        [StringLength(255)] 
        public string Email { get; set; }
        
        [StringLength(11)] 
        public string CPF { get; set; }
        public int DestinoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PedidoData { get; set; }

        public Destino Destino { get; set; }
    }
}
